import React from 'react';
import { shallow } from 'enzyme';
import ErrorPage from './ErrorPage';

describe('ErrorPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<ErrorPage />);
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
