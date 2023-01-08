<template>
  <div class="data">{{ case1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ case2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ case3 }}
    <div>
      <button @click="addToCart" class="buybtn">Buy</button>
    </div>
  </div>
</template>

<script>
import useSWRV from 'swrv'

const addToCart = () => {
    for (var i = 0; i < 1; i++) {
        cart.push(name[i].innerText)
        cart.push(parseInt(price[i].innerText))
    }
    console.log(cart)
}
const fetcher = function(url){
  return fetch(url).then(r => r.json())
}


export default {
  name: 'App',
  setup() {
    const { data: case1 } = useSWRV('https://localhost:7233/Case/1', fetcher)
    const { data: case2 } = useSWRV('https://localhost:7233/Case/2', fetcher)
    const { data: case3 } = useSWRV('https://localhost:7233/Case/3', fetcher)
 
    return {
      case1, case2, case3
    }
  },
}
</script>

<style>

</style>