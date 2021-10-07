import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

const NavLink = ({ url, label }) => {
  return (
    <Wrapper>
      <Link to={url}>{label}</Link>
    </Wrapper>
  );
};

export const Wrapper = styled.li`
  li {
    margin: 0 0.5rem;
  }

  a {
    color: var(--clr-grey-3);
    font-size: 1rem;
    text-transform: capitalize;
    letter-spacing: var(--spacing);
    padding: 0.5rem;

    &:hover {
      border-bottom: 2px solid var(--clr-primary-7);
    }
  }
`;

export default NavLink;
