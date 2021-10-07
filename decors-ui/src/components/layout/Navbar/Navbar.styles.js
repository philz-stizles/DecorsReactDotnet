import styled from 'styled-components'

export const NavbarWrapper = styled.nav`
  height: 5rem;
  display: flex;
  align-items: center;
  justify-content: center;

  .nav-center {
    width: 90vw;
    margin: 0 auto;
    max-width: var(--max-width);
  }

  .nav-header {
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  .nav-toggle {
    background: transparent;
    border: transparent;
    color: var(--clr-primary-5);
    cursor: pointer;
    svg {
      font-size: 2rem;
    }

    .nav-end {
      display: grid;
      grid-template-columns: 1fr 1fr;
      align-items: center;
      width: 225px;
    }
  }
  .nav-links {
    display: none;
  }
  .cart-btn-wrapper {
    display: none;
  }
  @media (min-width: 992px) {
    .nav-center {
      display: grid;
      grid-template-columns: auto 1fr auto;
      align-items: center;
    }
    .nav-links {
      display: flex;
      justify-content: center;
    }
    .cart-btn-wrapper {
      display: grid;
    }

    .nav-end {
      display: grid;
      grid-template-columns: 1fr 1fr;
      align-items: center;
      width: 325px;
    }
  }
`
