import React from 'react'
import { shallow } from 'enzyme'
import RegisterPage from './RegisterPage'

describe('RegisterPage component', () => {
  let wrapper

  beforeEach(() => {
    wrapper = shallow(<RegisterPage />)
  })

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy()
  })
})
