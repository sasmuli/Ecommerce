<script>
import useSWRV from 'swrv'
import { RouterView } from 'vue-router'

const fetcher = function(url){
  return fetch(url).then(r => r.json())
}

export default {
  name: 'App',
  setup() {
    const { data: mouse1 } = useSWRV('https://localhost:7233/Mouse/1', fetcher)
    const { data: headset2 } = useSWRV('https://localhost:7233/Headset/3', fetcher)
    const { data: cpu2 } = useSWRV('https://localhost:7233/Processor/2', fetcher)
    const { data: keyboard2 } = useSWRV('https://localhost:7233/Keyboard/2', fetcher)
    const { data: motherboard2 } = useSWRV('https://localhost:7233/Motherboard/2', fetcher)
 
    return {
      mouse1, headset2, cpu2, keyboard2, motherboard2
    }
  },
}
</script>

<template>
  <Router-view/>
  <div class="frontpage"> </div>
    <h1>You may like</h1>
  <div class="data">{{ mouse1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="frontpage"> </div>
    <h1>Best sellers</h1>
  <div class="data">{{ headset2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ cpu2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ keyboard2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ motherboard2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
</template>
