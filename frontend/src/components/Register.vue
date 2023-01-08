<template>
  <div id="app">
      <app-header></app-header>
      <form ref="form" class="contactform" @submit.prevent="login" >
          <h4> Register </h4>
          <fieldset>
              <div class="input">
                  <label class="label" for="name">First Name</label>
                  <input 
                  class="form" 
                  type="text" 
                  name="fristname" 
                  placeholder="Matti" 
                  v-model="name" required />
              </div>
              <div class="input">
                  <label class="label" for="name">Last Name</label>
                  <input 
                  class="form" 
                  type="text" 
                  name="lastname" 
                  placeholder="Meikäläinen" 
                  v-model="name" required />
              </div>
              <div>
                  <label class="label" for="email">Email address</label>
                  <input 
                  class="form" 
                  type="text" 
                  name="email" 
                  placeholder="email@address.com" 
                  v-model="name" required />
              </div>
              <div>
                  <label class="label" for="mobilenumber">Mobile Number</label>
                  <input 
                  class="form" 
                  type="text" v-on:keypress="NumbersOnly"
                  name="mNumber" 
                  placeholder="Mobile number" 
                  v-model="name" required />
              </div>
              
              <div class="haveAccount">
                  Already have an account? <span class="moveLogin" @click="moveToLogin">Login</span>
              </div>
              <button type="submit" class="registerbtn" id="register_button">
                  Register
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
        password: "123456",
      };
    },
    methods: {
      moveToLogin() {
        this.$router.push("/login");
      },
      NumbersOnly(event) {
        event = (event) ? event : window.event;
        var charCode = (event.which) ? event.which : event.keyCode;
        if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode !== 46) {
          event.preventDefault();;
        } else {
          return true;
        }
      }
    },
};
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
margin: 20px 0;
}

.contactform input[type="text"], [type="password"], [type="email"],
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
.registerbtn {
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
.registertbtn:hover {
  color: #2fbe72;
}

.moveLogin {
  background: none!important;
  border: none;
  padding: 0!important;
  color: #069;
  text-decoration: underline;
  cursor: pointer;
}

</style>