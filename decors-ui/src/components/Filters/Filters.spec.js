import React from 'react';
import { shallow } from 'enzyme';
import Filters from './Filters';
import { FilterProvider } from '../../context/filter_context';
import { ProductsProvider } from '../../context/products_context';

describe('Filters component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(
      <ProductsProvider>
        <FilterProvider>
          <Filters />
        </FilterProvider>
      </ProductsProvider>
    );
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
