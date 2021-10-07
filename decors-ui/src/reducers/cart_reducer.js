import {
  ADD_ITEM_TO_CART,
  CLEAR_CART,
  SET_CART_TOTALS,
  REMOVE_ITEM_FROM_CART,
  SET_ITEM_QUANTITY,
} from '../actions';

const cart_reducer = (state, action) => {
  if (action.type === ADD_ITEM_TO_CART) {
    const { id, color, amount, product } = action.payload;
    const existingItem = state.cart.find((item) => item.id === id + color);
    if (existingItem) {
      const newCart = state.cart.map((item) => {
        if (item.id === id + color) {
          const newAmount = item.amount + amount;
          return {
            ...item,
            amount: newAmount > item.max ? item.max : newAmount,
          };
        } else {
          return item;
        }
      });
      return { ...state, cart: newCart };
    } else {
      const newItem = {
        id: id + color,
        name: product.name,
        color,
        amount,
        image: product.images[0].url,
        price: product.price,
        max: product.stock,
      };
      return { ...state, cart: [...state.cart, newItem] };
    }
  }

  if (action.type === REMOVE_ITEM_FROM_CART) {
    return {
      ...state,
      cart: state.cart.filter((item) => item.id !== action.payload),
    };
  }

  if (action.type === CLEAR_CART) {
    return { ...state, cart: [] };
  }

  if (action.type === SET_ITEM_QUANTITY) {
    const { id, value } = action.payload;
    const updatedCart = state.cart.map((item) => {
      if (item.id === id) {
        let newQuantity = item.amount + value;
        if (newQuantity > item.max) {
          newQuantity = item.max;
        }

        if (newQuantity < 1) {
          newQuantity = 1;
        }
        return { ...item, amount: newQuantity };
      }
      return item;
    });
    return { ...state, cart: updatedCart };
  }

  if (action.type === SET_CART_TOTALS) {
    const updatedCartTotals = state.cart.reduce(
      (acc, { amount, price }) => {
        acc.total_items += amount;
        acc.total_amount += amount * price;

        return acc;
      },
      {
        total_items: 0,
        total_amount: 0,
      }
    );
    return { ...state, ...updatedCartTotals };
  }

  throw new Error(`No Matching "${action.type}" - action type`);
};

export default cart_reducer;
