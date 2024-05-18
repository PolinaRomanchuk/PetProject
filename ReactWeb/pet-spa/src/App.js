import axios from 'axios';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import React, { useState, useEffect } from 'react';
import MainMenu from './components/mainMenu/mainMenu.js';
import CreateUser from './components/createUser/createUser.js';
import Profile from './components/myProfile/Profile.js';
import { AuthProvider, AuthContext } from './components/login/auth.js';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("userId"))

  axios.interceptors.request.use(function (config) {
    config.headers['LoginHeader'] = localStorage.getItem('userId');
    return config;
  });

  return (
    <div>
      <BrowserRouter>
      <AuthProvider>
        <MainMenu />
        <Routes>
          <Route path="/login" element={<AuthProvider/>} />
          <Route path="/user" element={<CreateUser/>} />
          <Route path="/" element={<index/>} />
          <Route path="/profile" element={<Profile/>}/>
        </Routes>
        </AuthProvider>
      </BrowserRouter>
    </div>
  );
}

export default App;
