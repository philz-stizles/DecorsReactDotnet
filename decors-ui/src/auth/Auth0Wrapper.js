import React, { useState } from 'react'
import styled from 'styled-components'

const Auth0Wrapper = ({ children }) => {
  const { isLoading, error } = useState()

  if (isLoading) {
    return (
      <Wrapper>
        <h1>Loading....</h1>
      </Wrapper>
    )
  }
  if (error) {
    return (
      <Wrapper>
        <h1>{error.message}</h1>
      </Wrapper>
    )
  }
  return <>{children}</>
}

const Wrapper = styled.section`
  min-height: 100vh;
  display: grid;
  place-items: center;
`

export default Auth0Wrapper
