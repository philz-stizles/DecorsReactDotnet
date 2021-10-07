import React from 'react'
import styled from 'styled-components'

const Input = () => {
  return (
    <InputWrapper>
      <input type="text" />
    </InputWrapper>
  )
}

const InputWrapper = styled.div`
  margin-bottom: 10px;

  input {
    width: 100%;
    font-size: 1rem;
    padding: 0.5rem 1rem;
    border: 2px solid var(--clr-black);
    color: var(--clr-grey-3);
    border-top-left-radius: var(--radius);
    border-bottom-left-radius: var(--radius);
  }

  input::placeholder {
    color: var(--clr-black);
    text-transform: capitalize;
  }
`

export default Input
