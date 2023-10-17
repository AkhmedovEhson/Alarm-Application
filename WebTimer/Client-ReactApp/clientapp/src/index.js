import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { Provider } from 'react-redux';
import AppElement from './App';
import { configureStore } from '@reduxjs/toolkit';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';
import NotificationStoreElement from './Components/Layout/NotificationStore';
import AppRoutes from './AppRouter';
const root = ReactDOM.createRoot(document.getElementById('root'));


let defautstate =  {cash:0}
const reducer = (state = defautstate,action) => {
  switch (action.type)
  {
    case "Add":
      return {...state,cash: state.cash + action.payload}

    default:
      return state;
  }
};

const store = configureStore({
  reducer:{
    app:reducer
  }
});

root.render(
  <BrowserRouter> 
    <Provider store={store}>
      <Routes path='/'>
        { AppRoutes.map((route,index) => {
            const {element,...rest} = route;
            return <Route key = {index} {...rest} element = {element}/>
          }) }
      </Routes>
    </Provider>
  </BrowserRouter>
);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
