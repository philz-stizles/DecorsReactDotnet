import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

const SidebarLink = ({ url, label, onClick }) => {
  return (
    <SidebarLinkWrapper>
      <Link to={url} onClick={onClick}>
        {label}
      </Link>
    </SidebarLinkWrapper>
  );
};

export const SidebarLinkWrapper = styled.li`
  a {
    display: block;
    text-align: left;
    font-size: 1rem;
    text-transform: capitalize;
    padding: 1rem 1.5rem;
    color: var(--clr-grey-3);
    transition: var(--transition);
    letter-spacing: var(--spacing);
  }

  a:hover {
    padding: 1rem 1.5rem;
    padding-left: 2rem;
    background: var(--clr-grey-10);
    color: var(--clr-grey-2);
  }
`;

export default SidebarLink;
