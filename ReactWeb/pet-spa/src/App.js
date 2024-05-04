import axios from 'axios';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import React, { useState, useEffect } from 'react';
import Login from './components/login/login';

import LeftColumnMenu from './components/leftColumnMenu/leftColumnMenu';
import CreateUser from './components/createUser/createUser.js';



function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("userId"))

  axios.interceptors.request.use(function (config) {
    config.headers['LoginHeader'] = localStorage.getItem('userId');
    return config;
  });

  return (
    <div>
      <BrowserRouter>
        <LeftColumnMenu />
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/user" element={<CreateUser />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
