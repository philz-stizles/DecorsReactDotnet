import { lazy, Suspense } from 'react'
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import Loader from '../components/Loading/Loading'
import ProtectedRoutes from './ProtectedRoutes' //Authenticated routes
import PublicRoute from './PublicRoute'
import PrivateRoute from './PrivateRoute'

// Layout Components
import NavBar from '../components/layout/Navbar/Navbar'
import Footer from '../components/layout/Footer/Footer'

// Pages
const HomePage = lazy(() => import('../pages/Home/HomePage'))
const LoginPage = lazy(() => import('../pages/Auth/Login/LoginPage'))
const RegisterPage = lazy(() => import('../pages/Auth/Register/RegisterPage'))
const ProductsPage = lazy(() => import('../pages/Products/ProductsPage'))
const SingleProductPage = lazy(() =>
  import('../pages/SingleProduct/SingleProductPage')
)
const CartPage = lazy(() => import('../pages/Cart/CartPage'))
const NotFoundPage = lazy(() => import('../pages/NotFound/NotFoundPage'))
// const Register = lazy(() => import('components/Register'))
// const ForgotPassword = lazy(() => import('components/ForgotPassword'))
// const NoFoundComponent = lazy(() => import('components/NoFoundComponent'))

const Routes = () => {
  const isAuthenticated = '' // getToken()

  return (
    <Router>
      <Suspense fallback={<Loader />}>
        <Switch>
          <>
            <NavBar />

            <PublicRoute path="/" exact isAuthenticated={isAuthenticated}>
              <HomePage />
            </PublicRoute>

            <PublicRoute path="/login" isAuthenticated={isAuthenticated}>
              <LoginPage />
            </PublicRoute>

            <PublicRoute path="/register" isAuthenticated={isAuthenticated}>
              <RegisterPage />
            </PublicRoute>

            <PublicRoute
              path="/products"
              exact
              isAuthenticated={isAuthenticated}
            >
              <ProductsPage />
            </PublicRoute>

            <PublicRoute path="/products/:id" isAuthenticated={isAuthenticated}>
              <SingleProductPage />
            </PublicRoute>

            <PublicRoute path="/cart" isAuthenticated={isAuthenticated}>
              <CartPage />
            </PublicRoute>

            <Footer />
          </>
          <PrivateRoute path="/" isAuthenticated={isAuthenticated}>
            <ProtectedRoutes />
          </PrivateRoute>
          <Route path="*">
            <NotFoundPage />
          </Route>
        </Switch>
      </Suspense>
    </Router>
  )
}

export default Routes
