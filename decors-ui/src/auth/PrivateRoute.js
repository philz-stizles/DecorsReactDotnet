import React, { useState } from 'react'
import { Route, Redirect } from 'react-router-dom'

const PrivateRoute = ({ children, ...rest }) => {
  const { isAuthenticated } = useState()

  return (
    <Route
      {...rest}
      render={() => {
        return isAuthenticated ? children : <Redirect to="/" />
      }}
    />
  )
}

export default PrivateRoute
