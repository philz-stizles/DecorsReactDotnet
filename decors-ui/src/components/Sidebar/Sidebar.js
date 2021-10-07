import React, { useState } from 'react'
import logo from '../../assets/images/logo.svg'
import { FaTimes } from 'react-icons/fa'
import links from '../../lib/nav-links'
import styled from 'styled-components'
import { SidebarLink, LoginButton, LogoutButton, CartLink } from '..'
import { useSidebarContext } from '../../context/sidebar_context'

const Sidebar = () => {
  const { isAuthenticated } = useState()
  const sidebarContext = useSidebarContext()
  const { isSidebarOpen, closeSidebar } = sidebarContext

  return (
    <SidebarWrapper>
      <aside className={`sidebar${isSidebarOpen ? ' show-sidebar' : ''}`}>
        <div className="sidebar-header">
          <img src={logo} className="logo" alt="decours logo" />
          <button className="close-btn" type="button" onClick={closeSidebar}>
            <FaTimes />
          </button>
        </div>
        <ul className="links">
          {links.map(link => (
            <SidebarLink key={link.url} {...link} onClick={closeSidebar} />
          ))}
          {isAuthenticated && (
            <SidebarLink
              url="/checkout"
              label="Checkout"
              onClick={closeSidebar}
            />
          )}
        </ul>
        <div className="nav-end">
          <CartLink url="/cart" label="Cart" onClick={closeSidebar} />
          {isAuthenticated ? <LogoutButton /> : <LoginButton />}
        </div>
      </aside>
    </SidebarWrapper>
  )
}

const SidebarWrapper = styled.div`
  text-align: center;

  .sidebar-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem 1.5rem;
  }

  .close-btn {
    font-size: 2rem;
    background: transparent;
    border-color: transparent;
    color: var(--clr-primary-5);
    transition: var(--transition);
    cursor: pointer;
    color: var(--clr-red-dark);
    margin-top: 0.2rem;
  }

  .close-btn:hover {
    color: var(--clr-red-light);
  }

  .logo {
    justify-self: center;
    height: 45px;
  }

  .links {
    margin-bottom: 2rem;
  }

  .sidebar {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: var(--clr-white);
    transition: var(--transition);
    transform: translate(-100%);
    z-index: -1;
  }
  .show-sidebar {
    transform: translate(0);
    z-index: 999;
  }
  .cart-btn-wrapper {
    margin: 2rem auto;
  }
  @media screen and (min-width: 992px) {
    .sidebar {
      display: none;
    }
  }
`

export default Sidebar
