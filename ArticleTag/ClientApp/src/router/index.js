import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

/* Layout */
import Layout from '@/layout'

/**
 * Note: sub-menu only appear when route children.length >= 1
 * Detail see: https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 *
 * hidden: true                   if set true, item will not show in the sidebar(default is false)
 * alwaysShow: true               if set true, will always show the root menu
 *                                if not set alwaysShow, when item has more than one children route,
 *                                it will becomes nested mode, otherwise not show the root menu
 * redirect: noRedirect           if set noRedirect will no redirect in the breadcrumb
 * name:'router-name'             the name is used by <keep-alive> (must set!!!)
 * meta : {
    roles: ['admin','editor']    control the page roles (you can set multiple roles)
    title: 'title'               the name show in sidebar and breadcrumb (recommend set)
    icon: 'svg-name'             the icon show in the sidebar
    breadcrumb: false            if set false, the item will hidden in breadcrumb(default is true)
    activeMenu: '/example/list'  if set path, the sidebar will highlight the path you set
  }
 */

/**
 * constantRoutes
 * a base page that does not have permission requirements
 * all roles can be accessed
 */
export const constantRoutes = [
  {
    path: '/article',
    component: Layout,
    redirect: '/article',
    name: 'Article',
    meta: {
      title: '标注管理',
      icon: 'form'
    },
    children: [
      {
        path: 'articlelist',
        component: () => import('@/views/article/articlelist/index'),
        name: 'Articlelist',
        meta: {
          title: '文章列表'
        }
      },
      {
        path: 'markarticle',
        component: () => import('@/views/article/markarticle/index'),
        name: 'MarkArticle',
        meta: {
          title: '标注文章'
        }
      },
      {
        path: 'auditarticle/:id',
        component: () => import('@/views/article/auditarticle/index'),
        name: 'AuditArticle',
        hidden: true,
        meta: {
          title: '审核文章'
        }
      },
      {
        path: 'viewarticle/:id',
        component: () => import('@/views/article/viewarticle/index'),
        name: 'ViewArticle',
        hidden: true,
        meta: {
          title: '查看文章'
        }
      }
    ]
  },
  {
    path: '/user',
    component: Layout,
    redirect: '/user',
    name: 'User', // 路由的名字，<keep-alive>中会使用到
    hidden: true,
    meta: {
      title: '用户',// 该路由在侧边栏和面包屑中显示的名字
      icon: 'user'
    },
    children: [
      {
        path: 'userlist',
        component: () => import('@/views/user/userlist/index'),
        name: 'Userlist',
        meta: {
          title: '用户列表'
        }
      },
      {
        path: 'usergroup',
        component: () => import('@/views/user/usergroup/index'),
        name: 'Usergroup',
        meta: {
          title: '用户组管理'
        }
      },
      {
        path: 'admin',
        component: () => import('@/views/user/admin/index'),
        name: 'Admin',
        meta: {
          title: '后台管理员'
        }
      }
    ]
  },

  {
    path: '/login',
    component: () => import('@/views/login/index'),
    hidden: true
  },

  {
    path: '/404',
    component: () => import('@/views/404'),
    hidden: true
  },

  {
    path: '/',
    component: Layout,
    redirect: '/article/markarticle',
    hidden: true,
    children: [{
      path: 'markarticle',
      name: 'markarticle',
      component: () => import('@/views/article/markarticle/index'),
      meta: {
        title: '文章列表'
      }
    }]
  },
  // 404 page must be placed at the end !!!
  { path: '*', redirect: '/404', hidden: true }
]

const createRouter = () => new Router({
  // mode: 'history', // require service support
  scrollBehavior: () => ({ y: 0 }),
  routes: constantRoutes
})

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter () {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher // reset router
}

export default router
