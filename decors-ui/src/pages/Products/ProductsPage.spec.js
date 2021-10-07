import React from 'react';
import { shallow } from 'enzyme';
import ProductsPage from './ProductsPage';

describe('ProductsPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<ProductsPage />);
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
