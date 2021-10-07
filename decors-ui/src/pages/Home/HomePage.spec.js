import React from 'react';
import { shallow } from 'enzyme';
import HomePage from './HomePage';

describe('HomePage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<HomePage />);
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
