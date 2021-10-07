import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import logo from '../../assets/images/logo.svg'; // relative path to image

const Logo = () => {
  return (
    <LogoWrapper to="/">
      <img src={logo} alt="decor logo" />
    </LogoWrapper>
  );
};

export const LogoWrapper = styled(Link)`
  img {
    width: 175px;
    margin-left: -15px;
  }
`;

export default Logo;
