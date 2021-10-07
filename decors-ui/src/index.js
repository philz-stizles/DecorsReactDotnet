import React from 'react'
import ReactDOM from 'react-dom'
import './index.css'
import App from './App'

import { createBrowserHistory } from 'history'

// Context Providers
import { SidebarProvider } from './context/sidebar_context'
import { ProductsProvider } from './context/products_context'
import { FilterProvider } from './context/filter_context'
import { CartProvider } from './context/cart_context'

export const history = createBrowserHistory()

ReactDOM.render(
  <SidebarProvider>
    <ProductsProvider>
      <FilterProvider>
        <CartProvider>
          <App />
        </CartProvider>
      </FilterProvider>
    </ProductsProvider>
  </SidebarProvider>,
  document.getElementById('root')
)
