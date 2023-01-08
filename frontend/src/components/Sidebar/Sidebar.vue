<script>
import SidebarLink from './SidebarLink.vue'
import { collapsed, toggleSidebar, sidebarWidth} from './state'

export default {
    props: {},
    components: { SidebarLink },
    setup() {
        return { collapsed, toggleSidebar, sidebarWidth }
    }
}
</script>

<template>
    <div class="sidebar" :style="{ width: sidebarWidth }">
        <h2>
            <span v-if="collapsed">
                <div>G</div>
                <div>19</div>
            </span>
            <span v-else>Categories</span> 
        </h2>
            <SidebarLink to="/cases" icon="fa-solid fa-grip-lines-vertical">Cases</SidebarLink>
            <SidebarLink to="/computers" icon="fa-solid fa-grip-lines-vertical">Computers</SidebarLink>
            <SidebarLink to="/coolers" icon="fa-solid fa-grip-lines-vertical">Coolers</SidebarLink>
            <SidebarLink to="/gpu" icon="fa-solid fa-grip-lines-vertical">GPU</SidebarLink>
            <SidebarLink to="/headsets" icon="fa-solid fa-grip-lines-vertical">Headsets</SidebarLink>
            <SidebarLink to="/keyboards" icon="fa-solid fa-grip-lines-vertical">Keyboards</SidebarLink>
            <SidebarLink to="/monitors" icon="fa-solid fa-grip-lines-vertical">Monitors</SidebarLink>
            <SidebarLink to="/motherboards" icon="fa-solid fa-grip-lines-vertical">Motherboards</SidebarLink>
            <SidebarLink to="/mouses" icon="fa-solid fa-grip-lines-vertical">Mouses</SidebarLink>
            <SidebarLink to="/psu" icon="fa-solid fa-grip-lines-vertical">PSU</SidebarLink>
            <SidebarLink to="/cpu" icon="fa-solid fa-grip-lines-vertical">CPU</SidebarLink>
            <SidebarLink to="/ram" icon="fa-solid fa-grip-lines-vertical">RAMS</SidebarLink>
        <span
            class="collapse-icon"
            :class="{ 'rotate-180': collapsed }"
            @click="toggleSidebar"
        >
            <i class="fas fa-angle-double-left" />
        </span>
    </div>
</template>


<style>
:root {
  --sidebar-bg-color: #2f855a;
  --sidebar-item-hover: #38a169;
  --sidebar-item-active: #276749;
}
</style>

<style scoped>
.sidebar {
  color: white;
  background-color: var(--sidebar-bg-color);
  float: left;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  bottom: 0;
  padding: 0.5em;
  transition: 0.4s ease;
  display: flex;
  flex-direction: column;
}
.sidebar h1 {
  height: 2em;
}
.collapse-icon {
  position: absolute;
  bottom: 0;
  padding: 0.75em;
  color: rgba(255, 255, 255, 0.7);
  transition: 0.2s linear;
}
.rotate-180 {
  transform: rotate(180deg);
  transition: 0.2s linear;
}
</style>
