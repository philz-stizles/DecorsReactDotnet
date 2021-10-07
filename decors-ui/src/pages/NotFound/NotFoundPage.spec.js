import React from 'react'
import { shallow } from 'enzyme'
import NotFoundPage from './NotFoundPage'

describe('NotFoundPage component', () => {
  let wrapper

  beforeEach(() => {
    wrapper = shallow(<NotFoundPage />)
  })

  test('should render without crashing', () => {
    expect(wrapper).toBeTruthy()
  })
})
