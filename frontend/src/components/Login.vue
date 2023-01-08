<template>
  <div>
      <app-header></app-header>
      <form ref="form" class="contactform" @submit.prevent="login" >
          <h4> Login </h4>
          <fieldset>
              <div>
                  <label class="label" for="email">Email address</label>
                  <input 
                  class="form" 
                  type="text" 
                  name="email" 
                  placeholder="email@adress.com" 
                  v-model="name" required />
              </div>
              <div class="input">
                  <label class="label" for="password">Password</label>
                  <input 
                  class="form" 
                  type="password" 
                  name="password" 
                  placeholder="password123" 
                  v-model="name" required />
              </div>
              <div class="noAccount">
                  You don't have an account? <span class="moveRegister" @click="moveToRegister">Register</span>
              </div>
              <button class="loginbtn" type="submit"  id="login_button">
                  Login
              </button>
          </fieldset>
      </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    moveToRegister() {
      this.$router.push("/register");
    },
  }
}
</script>


<style scoped>
.contactform {
font-size: 16px;
width: 500px;
padding: 15px 30px;
border-radius: 4px;
margin: 50px auto;
width: 52vw;
background-color: #fff;
box-shadow: 0 4px 6px 0 rgba(0, 0, 0, 0.3);
}

.contactform fieldset {
margin: 24px 0 0 0;
}

.contactform div {
position: relative;
margin: 40px 0;
}

.contactform input[type="text"], [type="password"],
.contactform input[type="email"],
.contactform textarea,
.contactform select {
padding: 12px;
border: 1px solid #cfd9db;
background-color: #ffffff;
border-radius: 0.25em;
box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.08);
}

.contactform textarea {
min-height: 120px;
resize: vertical;
overflow: auto;
}

.contactform .label {
display: block;
}

.contactform h4,
.contactform .label {
color: #000000;
margin-bottom: 10px;
}

</style>

<style>
.loginbtn {
  padding: 0.7rem 2rem;
  margin-top: 5px;
  margin-left: 10px;
  border: none;
  cursor: pointer;
  background: #2f855a;
  border-radius: 20px;
  text-align: center;
  color: #fff;
  font-size: 17px;
  font-weight: bold;
  letter-spacing: 2px;
  text-transform: uppercase;
  box-shadow: 24px 24px 84px #2d8d5b, inset -12px -12px 14px #3abe7c,inset 10px 10px 20px #17d177;
}
.loginbtn:hover {
  color: #2fbe72;
}

.moveRegister {
  background: none!important;
  border: none;
  padding: 0!important;
  color: #069;
  text-decoration: underline;
  cursor: pointer;
}
</style>