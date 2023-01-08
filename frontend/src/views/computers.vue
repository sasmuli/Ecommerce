<template>
  <div class="data">{{ computer }}
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
    const { data: computer } = useSWRV('https://localhost:7233/Computers', fetcher)
 
    return {
      computer,
    }
  },
}
</script>

