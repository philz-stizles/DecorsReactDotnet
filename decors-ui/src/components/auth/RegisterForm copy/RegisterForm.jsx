import React, { useState } from 'react'
import styled from 'styled-components'
// Custom UI Components
import { Input } from '../../ui'

const RegisterForm = () => {
  const [registerInputs, setRegisterInput] = useState({})
  const {} = registerInputs

  const submitHandler = () => {}

  return (
    <StyledForm submit={submitHandler}>
      <h3>Register</h3>
      <Input />
      <Input />
      <Input />
    </StyledForm>
  )
}

const StyledForm = styled.form`
  background: #fff;
  min-width: 430px;
`

export default RegisterForm
