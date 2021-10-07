import React from 'react';
import { shallow } from 'enzyme';
import CheckoutPage from './CheckoutPage';
import { CartProvider } from '../../context/cart_context';

describe('CheckoutPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(
      <CartProvider>
        <CheckoutPage />
      </CartProvider>
    );
  });

  test('should render without crashing', () => {
    jest.mock('react', () => {
      const ActualReact = require.requireActual('react');
      return {
        ...ActualReact,
        useContext: () => ({ state: { cart: 'mocked context' } }),
      };
    });
    expect(wrapper).toBeTruthy();
  });
});
