import React from 'react'
import styled from 'styled-components'
// Custom Components
import RegisterForm from '../../../components/auth/RegisterForm/RegisterForm'

const RegisterPage = () => {
  return (
    <main>
      <RegisterPageWrapper>
        <RegisterForm />
      </RegisterPageWrapper>
    </main>
  )
}

const RegisterPageWrapper = styled.div`
  display: flex;
  flex: 1;
  justify-content: center;
  align-items: center;

  @media (min-width: 992px) {
  }
`
export default RegisterPage
