import React, { useContext } from 'react';
import cartReducer from '../reducers/cart_reducer';
import {
  ADD_ITEM_TO_CART,
  REMOVE_ITEM_FROM_CART,
  SET_ITEM_QUANTITY,
  CLEAR_CART,
  SET_CART_TOTALS,
} from '../actions';

const getCartFromLocalStorage = () => {
  const appData = localStorage.getItem('comfydecors');
  if (appData) {
    const parsedAppData = JSON.parse(appData);
    if (parsedAppData) {
      return parsedAppData.cart;
    } else {
      return [];
    }
  } else {
    return [];
  }
};

const initialState = {
  cart: getCartFromLocalStorage(),
  total_items: 0,
  total_amount: 0,
  shipping_fee: 534,
};

const CartContext = React.createContext();

export const CartProvider = ({ children }) => {
  const [state, dispatch] = React.useReducer(cartReducer, initialState);

  React.useEffect(() => {
    // Anytime the cart changes, set cart total amount
    dispatch({ type: SET_CART_TOTALS });

    // Anytime the cart changes, store in local storage
    const appData = localStorage.getItem('comfydecors');
    let updatedAppData;
    if (appData) {
      const parsedAppData = JSON.parse(appData);
      updatedAppData = { ...parsedAppData, cart: state.cart };
    } else {
      updatedAppData = { cart: state.cart };
    }
    localStorage.setItem('comfydecors', JSON.stringify(updatedAppData));
  }, [state.cart]);

  const addToCart = (id, color, amount, product) => {
    dispatch({
      type: ADD_ITEM_TO_CART,
      payload: { id, color, amount, product },
    });
  };

  const removeFromCart = (id) => {
    dispatch({ type: REMOVE_ITEM_FROM_CART, payload: id });
  };

  const clearCart = () => {
    dispatch({ type: CLEAR_CART });
  };

  const setItemQuantity = (id, value) => {
    dispatch({ type: SET_ITEM_QUANTITY, payload: { id, value } });
  };

  return (
    <CartContext.Provider
      value={{
        ...state,
        addToCart,
        removeFromCart,
        clearCart,
        setItemQuantity,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};
// make sure use
export const useCartContext = () => {
  return useContext(CartContext);
};
