import { Suspense } from 'react'
import { Route, Switch } from 'react-router-dom'
import Loader from '../components/Loading/Loading'

import { lazy } from 'react'

const routes = [
  // {
  //   path: 'home',
  //   component: lazy(() => import('../pages/Home')),
  //   exact: true,
  // },
  {
    path: 'checkout',
    component: lazy(() => import('../pages/Checkout/CheckoutPage')),
    exact: true,
  },
]

const ProtectedRoutes = () => (
  <Switch>
    <Suspense fallback={<Loader />}>
      {routes.map(({ component: Component, path, exact }) => (
        <Route path={`/${path}`} key={path} exact={exact}>
          <Component />
        </Route>
      ))}
    </Suspense>
  </Switch>
)

export default ProtectedRoutes
