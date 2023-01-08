<template>
  <div class="data">{{ keyboard1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ keyboard2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
</template>

<script>
import useSWRV from 'swrv'

const fetcher = function(url){
  return fetch(url).then(r => r.json())
}

export default {
  name: 'App',
  setup() {
    const { data: keyboard1 } = useSWRV('https://localhost:7233/Keyboard/1', fetcher)
    const { data: keyboard2 } = useSWRV('https://localhost:7233/Keyboard/2', fetcher)
 
    return {
      keyboard1, keyboard2
    }
  },
}
</script>
