<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Sidebar from '@/components/Sidebar/Sidebar.vue'
import { sidebarWidth } from './components/Sidebar/state'
import Login from '@/components/Login.vue'
</script>


<template>
  <Sidebar />
  <div :style="{ 'margin-left': sidebarWidth}"></div>
  <header>
    <div id="navBar" class="navBar">
      <button id="navBarButton" onclick="window.location.href='/'" ><i class="fa fa-home"></i> Home</button>
      <button id="navBarButton" onclick="window.location.href='/Contact'"><i class="fa-solid fa-phone"></i> Contact</button>
      <button id="navBarButton" onclick="window.location.href='/Cart'"><i class="fa-solid fa-cart-shopping"></i> CART</button>
      <button id="navBarButton" onclick="window.location.href='/login'"><i class="fa-solid fa-right-to-bracket"></i> LOG IN</button>
    </div>
  </header>
  <RouterView />
  <footer class="footer">
    <p> Email: <button id="textButton" onclick="window.location.href='/Contact'">groub19store@gmail.com</button>  </p>
    <p> Phone Number: +35845321654 </p>
    <p> Address: Myllykatu 160, Oulu 90069 </p>
  </footer>
</template>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background-image: url(./assets/bc.jpg);
  background-size: cover;
  height: 100vh;
  width: 100%;
}
.footer {
  background-image: url(./assets/bc.jpg);
  background-size: cover;
  height: 100vh;
  width: 100%;
}
.navBar {
  background-image: url(./assets/bc.jpg);
  background-size: cover;
  height: 100vh;
  width: 100%;
}
</style>
