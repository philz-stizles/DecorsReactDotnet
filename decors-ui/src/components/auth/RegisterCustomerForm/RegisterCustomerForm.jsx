import React, { useState } from 'react'
import styled from 'styled-components'
// Custom UI Components
import { Input } from '../../ui'

const RegisterCustomerForm = () => {
  const [registerInputs, setRegisterInput] = useState({})
  const {} = registerInputs

  const submitHandler = () => {}

  return (
    <StyledForm submit={submitHandler}>
      <Input label="Email" />
      <Input />
      <Input />
    </StyledForm>
  )
}

const StyledForm = styled.form`
  background: #fff;
  min-width: 430px;
`

export default RegisterCustomerForm
