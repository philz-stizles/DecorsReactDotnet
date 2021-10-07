import React from 'react';
import { shallow } from 'enzyme';
import SingleProductPage from './SingleProductPage';
import { ProductsProvider } from '../../context/products_context';

jest.mock('react-router-dom', () => ({
  ...jest.requireActual('react-router-dom'), // use actual for all non-hook parts
  useParams: () => ({
    id: 'company-id1',
  }),
  useRouteMatch: () => ({ url: '/company/company-id1/team/team-id1' }),
}));

describe('SingleProductPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(
      <ProductsProvider>
        <SingleProductPage />
      </ProductsProvider>
    );
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
