import React, { useContext } from 'react';
import sidebarReducer from '../reducers/sidebar_reducer';
// import { products_url as url } from '../utils/constants';
import { SIDEBAR_OPEN, SIDEBAR_CLOSE } from '../actions';

const initialState = {
  isSidebarOpen: false,
};

const SidebarContext = React.createContext();

export const SidebarProvider = ({ children }) => {
  // useReducer is usually preferable to useState when you have complex state logic
  // that involves multiple sub-values or when the next state depends on the
  // previous one. useReducer also lets you optimize performance for components
  // that trigger deep updates because you can pass dispatch down instead of callbacks.
  const [state, dispatch] = React.useReducer(sidebarReducer, initialState);

  const openSidebar = () => {
    dispatch({ type: SIDEBAR_OPEN });
  };

  const closeSidebar = () => {
    dispatch({ type: SIDEBAR_CLOSE });
  };

  return (
    <SidebarContext.Provider
      value={{
        ...state,
        openSidebar,
        closeSidebar,
      }}
    >
      {children}
    </SidebarContext.Provider>
  );
};
// make sure use
export const useSidebarContext = () => {
  return useContext(SidebarContext);
};
