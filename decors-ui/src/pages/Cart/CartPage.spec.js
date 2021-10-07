import React from 'react';
import { shallow } from 'enzyme';
import CartPage from './CartPage';
import { CartProvider } from '../../context/cart_context';

describe('CartPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(
      <CartProvider>
        <CartPage />
      </CartProvider>
    );
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
