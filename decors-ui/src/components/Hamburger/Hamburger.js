import React from 'react';
import styled from 'styled-components';
import { FaBars } from 'react-icons/fa';

const Hamburger = ({ onClick }) => {
  return (
    <HamburgerWrapper onClick={onClick}>
      <FaBars />
    </HamburgerWrapper>
  );
};

export const HamburgerWrapper = styled.button`
  background: transparent;
  border: transparent;
  color: var(--clr-primary-5);
  cursor: pointer;

  svg {
    font-size: 2rem;
  }

  @media (min-width: 992px) {
    display: none;
  }
`;

export default Hamburger;
