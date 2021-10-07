import React, { useState } from 'react'
import {
  Hamburger,
  Logo,
  NavLink,
  LoginButton,
  LogoutButton,
  CartLink,
} from '../../'
import { useSidebarContext } from '../../../context/sidebar_context'
import links from '../../../lib/nav-links'
import { NavbarWrapper } from './Navbar.styles'

const Navbar = () => {
  const { isAuthenticated } = useState()
  const { closeSidebar, openSidebar } = useSidebarContext()

  return (
    <NavbarWrapper>
      <div className="nav-center">
        <div className="nav-header">
          <Logo />
          <Hamburger onClick={openSidebar} />
        </div>
        <ul className="nav-links">
          {links.map(link => (
            <NavLink key={link.url} {...link} />
          ))}
          {isAuthenticated && <NavLink url="/checkout" label="checkout" />}
        </ul>
        <div className="nav-end">
          <CartLink url="/cart" label="Cart" onClick={closeSidebar} />
          {isAuthenticated ? <LogoutButton /> : <LoginButton />}
        </div>
      </div>
    </NavbarWrapper>
  )
}

export default Navbar
