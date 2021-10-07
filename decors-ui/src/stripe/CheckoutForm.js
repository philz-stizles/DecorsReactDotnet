import React, { useEffect, useState } from 'react';
import { useStripe, useElements, CardElement } from '@stripe/react-stripe-js';
import { useAuth0 } from '@auth0/auth0-react';
import CardSection from './CardSection';
import { useHistory } from 'react-router-dom';
import { useCartContext } from '../context/cart_context';
import axios from 'axios';

export default function CheckoutForm() {
  const { cart, total_amount, shipping_fee, clearCart } = useCartContext();
  const { user } = useAuth0();
  const history = useHistory();

  // STRIPE
  const [succeeded, setSucceeded] = useState(false);
  const [error, setError] = useState(null);
  // const [processing, setProcessing] = useState('');
  const [disabled, setDisabled] = useState(true);
  const [clientSecret, setClientSecret] = useState('');

  const stripe = useStripe();
  const elements = useElements();

  const createPaymentIntent = async () => {
    try {
      const { data } = await axios.post(
        '/.netlify/functions/create-payment-intent',

        JSON.stringify({ cart, shipping_fee, total_amount })
      );
      // console.log(data);
      setClientSecret(data.clientSecret);
    } catch (error) {
      console.log(error.response);
    }
  };
  useEffect(() => {
    createPaymentIntent();
    // eslint-disable-next-line
  }, []);

  const handleSubmit = async (event) => {
    // We don't want to let default form submission happen here,
    // which would refresh the page.
    event.preventDefault();

    if (!stripe || !elements) {
      // Stripe.js has not yet loaded.
      // Make sure to disable form submission until Stripe.js has loaded.
      setDisabled(true);
      return;
    }

    const result = await stripe.confirmCardPayment(clientSecret, {
      payment_method: {
        card: elements.getElement(CardElement),
        billing_details: {
          name: user.name,
        },
      },
    });

    if (result.error) {
      // Show error to your customer (e.g., insufficient funds)
      console.log(result.error.message);
      setError(`Payment failed ${result.error.message}`);
      // setProcessing(false);
    } else {
      // The payment has been processed!
      if (result.paymentIntent.status === 'succeeded') {
        // Show a success message to your customer
        // There's a risk of the customer closing the window before callback
        // execution. Set up a webhook or plugin to listen for the
        // payment_intent.succeeded event that handles any business critical
        // post-payment actions.
        setError(null);
        // setProcessing(false);
        setSucceeded(true);
        // setTimeout(() => {
        //   clearCart();
        //   history.push('/');
        // }, 10000);
      }
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <CardSection />
      <button disabled={!stripe}>Confirm order</button>
      {/* Show any error that happens when processing the payment */}
      {error && (
        <div className="card-error" role="alert">
          {error}
        </div>
      )}
    </form>
  );
}
