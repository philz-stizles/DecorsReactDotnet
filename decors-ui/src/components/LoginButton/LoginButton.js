import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import styled from 'styled-components'
import { FaUserPlus } from 'react-icons/fa'

const LoginButton = () => {
  return (
    <StyledLink to="/register">
      Login | Register <FaUserPlus />
    </StyledLink>
  )
}

const StyledLink = styled(Link)`
  display: flex;
  align-items: center;
  background: transparent;
  border-color: transparent;
  // font-size: 1.2rem;
  cursor: pointer;
  color: var(--clr-grey-1);
  letter-spacing: var(--spacing);

  svg {
    margin-left: 5px;
  }
`

export default LoginButton
