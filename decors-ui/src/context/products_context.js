import axios from 'axios';
import React, { useContext } from 'react';
import productsReducer from '../reducers/products_reducer';
import { products_url as url } from '../lib/api_urls';
import {
  GET_PRODUCTS_ERROR,
  GET_PRODUCTS_START,
  GET_PRODUCTS_SUCCESS,
  GET_SINGLE_PRODUCT_ERROR,
  GET_SINGLE_PRODUCT_START,
  GET_SINGLE_PRODUCT_SUCCESS,
} from '../actions';

const initialState = {
  products_loading: false,
  products_error: false,
  products: [],
  featured_products: [],
  single_product_loading: false,
  single_product_error: false,
  single_product: {},
};

const ProductsContext = React.createContext();

export const ProductsProvider = ({ children }) => {
  // useReducer is usually preferable to useState when you have complex state logic
  // that involves multiple sub-values or when the next state depends on the
  // previous one. useReducer also lets you optimize performance for components
  // that trigger deep updates because you can pass dispatch down instead of callbacks.
  const [state, dispatch] = React.useReducer(productsReducer, initialState);

  const fetchProducts = async (url) => {
    dispatch({ type: GET_PRODUCTS_START });
    try {
      const response = await axios.get(url);

      dispatch({ type: GET_PRODUCTS_SUCCESS, payload: response.data });
    } catch (error) {
      console.log(error.message);
      dispatch({ type: GET_PRODUCTS_ERROR });
    }
  };

  const fetchSingleProduct = async (url) => {
    dispatch({ type: GET_SINGLE_PRODUCT_START });
    try {
      const response = await axios.get(url);

      dispatch({ type: GET_SINGLE_PRODUCT_SUCCESS, payload: response.data });
    } catch (error) {
      console.log(error.message);
      dispatch({ type: GET_SINGLE_PRODUCT_ERROR });
    }
  };

  React.useEffect(() => {
    fetchProducts(url);
  }, []);

  return (
    <ProductsContext.Provider value={{ ...state, fetchSingleProduct }}>
      {children}
    </ProductsContext.Provider>
  );
};
// make sure use
export const useProductsContext = () => {
  return useContext(ProductsContext);
};
