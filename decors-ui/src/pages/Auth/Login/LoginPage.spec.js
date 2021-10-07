import React from 'react'
import { shallow } from 'enzyme'
import LoginPage from './LoginPage'

describe('LoginPage component', () => {
  let wrapper

  beforeEach(() => {
    wrapper = shallow(<LoginPage />)
  })

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy()
  })
})
