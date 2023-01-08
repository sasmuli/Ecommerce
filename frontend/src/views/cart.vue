<template>
    <div>
        <app-header></app-header>
        <form ref="form" class="shoppingCart" @submit.prevent="login" >
            <h4> Cart </h4>
            <fieldset>
                <div>
                    <label class="label" for="email">Items</label>
                </div>
                <button class="payBtn" type="submit"  id="login_button">
                    Continue to payment
                </button>
            </fieldset>
        </form>
    </div>
  </template>
  
  <script>
  export default {
    
  }
  </script>
  
  
  <style scoped>
  .shoppingCart {
  font-size: 16px;
  width: 500px;
  padding: 15px 30px;
  border-radius: 4px;
  margin: 50px auto;
  width: 52vw;
  background-color: #fff;
  box-shadow: 0 4px 6px 0 rgba(0, 0, 0, 0.3);
  }
  
  .shoppingCart fieldset {
  margin: 24px 0 0 0;
  }
  
  .shoppingCart div {
  position: relative;
  margin: 100px 0;
  }
  .shoppingCart select {
  padding: 12px;
  border: 1px solid #cfd9db;
  background-color: #ffffff;
  border-radius: 0.25em;
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.08);
  }
  
  .shoppingCart h4,
  .shoppingCart .label {
  color: #000000;
  margin-bottom: 10px;
  }
  
  </style>
  
  <style>
  .payBtn {
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
  .payBtn:hover {
    color: #2fbe72;
  }

  </style>