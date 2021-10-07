import React from 'react';
import { shallow } from 'enzyme';
import AboutPage from './AboutPage';

describe('AboutPage component', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<AboutPage />);
  });

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy();
  });
});
