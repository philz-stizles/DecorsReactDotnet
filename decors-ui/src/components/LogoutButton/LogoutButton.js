import React, { useState } from 'react'
import styled from 'styled-components'
import { FaSignOutAlt } from 'react-icons/fa'
import { useCartContext } from '../../context/cart_context'

const LogoutButton = () => {
  const { logout } = useState()
  const { clearCart } = useCartContext()
  return (
    <Wrapper
      onClick={() => {
        clearCart()
        logout({ returnTo: window.location.origin })
      }}
    >
      Logout <FaSignOutAlt />
    </Wrapper>
  )
}

const Wrapper = styled.button`
  display: flex;
  align-items: center;
  background: transparent;
  border-color: transparent;
  font-size: 1.5rem;
  cursor: pointer;
  color: var(--clr-grey-1);
  letter-spacing: var(--spacing);

  svg {
    margin-left: 5px;
  }
`

export default LogoutButton
