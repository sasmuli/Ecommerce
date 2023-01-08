<template>
  <div id="app">
    <app-header></app-header>
    <form ref="form" class="contactform" @submit.prevent="sendEmail">
       <h4> Contact Us </h4>
      <fieldset>
        <div>
          <label class="label" for="name">Name</label>
          <input type="text" name="from_name" id="name" v-model="name" required />
        </div>
        <div>
          <label class="label" for="email">Email</label>
          <input type="email" name="email_id" id="email" v-model="email.value" required />
        </div>
        <div>
          <label class="label" for="textarea">Message</label>
          <textarea class="message" name="message" id="textarea" v-model="message.text" :maxlength="message.maxlength"></textarea>
          <span class="counter">{{ message.text.length }} / {{ message.maxlength }}</span>
        </div>
        <div>
          <button class="submitbtn" type="submit">Send a message</button>
        </div>
      </fieldset>
    </form>
  </div>
</template>
  
<script>

import emailjs from '@emailjs/browser';

export default {
  name: 'app',
  data: function() {
    return {
      name: "",
      email: {
        value: "",
      },
      message: {
        text: "",
        maxlength: 255
      },
    }
  },
  methods: {
    submit: function() {
      this.submitted = true;
    },
    sendEmail() {
      emailjs.sendForm('service_a4fm5kk', 'template_33hrwsq', this.$refs.form, 'gflxB7s4eEVe0yG89')
        .then((result) => {
            console.log('SUCCESS!', result.text);
        }, (error) => {
            console.log('FAILED...', error.text);
        });
    }
  },
  
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
  margin: 20px 0;
}

.contactform input[type="text"],
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

form.contactform textarea#textarea {
  margin-left: 61px;
  padding: 18px;
}
</style>

<style>
.submitbtn {
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
.submitbtn:hover {
  color: #2fbe72;
}
</style>