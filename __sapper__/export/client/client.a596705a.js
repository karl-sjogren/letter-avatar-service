import{a as e,b as t,c as s,d as r,e as n,f as a,g as o,h as l,i as c,j as i,k as u,l as f,m as p,n as m,o as h,p as g,q as d,r as v,s as $,t as b,u as y,v as E,w as S,x as w,y as N}from"./chunk.88cee8dd.js";import{a as _}from"./chunk.7b9d3742.js";const L={},P=()=>({});function R(e){var t,s,m,h,g,d,v,$,b,y,E,S,w,N,_,L,P,R,A,x;return{c(){t=r("nav"),s=r("ul"),m=r("li"),h=r("span"),g=n("Letter Avatar Service"),d=a(),v=r("li"),$=r("a"),b=n("home"),E=a(),S=r("li"),w=r("a"),N=n("installing"),L=a(),P=r("li"),R=r("a"),A=n("using"),this.h()},l(e){t=o(e,"NAV",{class:!0},!1);var r=l(t);s=o(r,"UL",{class:!0},!1);var n=l(s);m=o(n,"LI",{class:!0},!1);var a=l(m);h=o(a,"SPAN",{class:!0},!1);var u=l(h);g=c(u,"Letter Avatar Service"),u.forEach(i),a.forEach(i),d=c(n,"\n    "),v=o(n,"LI",{class:!0},!1);var f=l(v);$=o(f,"A",{class:!0,href:!0},!1);var p=l($);b=c(p,"home"),p.forEach(i),f.forEach(i),E=c(n,"\n    "),S=o(n,"LI",{class:!0},!1);var y=l(S);w=o(y,"A",{class:!0,href:!0},!1);var _=l(w);N=c(_,"installing"),_.forEach(i),y.forEach(i),L=c(n,"\n    "),P=o(n,"LI",{class:!0},!1);var x=l(P);R=o(x,"A",{class:!0,href:!0},!1);var C=l(R);A=c(C,"using"),C.forEach(i),x.forEach(i),n.forEach(i),r.forEach(i),this.h()},h(){h.className="svelte-12bfisv",m.className="brand svelte-12bfisv",$.className=y=(void 0===e.segment?"selected":"")+" svelte-12bfisv",$.href=".",v.className="svelte-12bfisv",w.className=_=("installing"===e.segment?"selected":"")+" svelte-12bfisv",w.href="installing",S.className="svelte-12bfisv",R.className=x=("using"===e.segment?"selected":"")+" svelte-12bfisv",R.href="using",P.className="svelte-12bfisv",s.className="svelte-12bfisv",t.className="svelte-12bfisv"},m(e,r){u(e,t,r),f(t,s),f(s,m),f(m,h),f(h,g),f(s,d),f(s,v),f(v,$),f($,b),f(s,E),f(s,S),f(S,w),f(w,N),f(s,L),f(s,P),f(P,R),f(R,A)},p(e,t){e.segment&&y!==(y=(void 0===t.segment?"selected":"")+" svelte-12bfisv")&&($.className=y),e.segment&&_!==(_=("installing"===t.segment?"selected":"")+" svelte-12bfisv")&&(w.className=_),e.segment&&x!==(x=("using"===t.segment?"selected":"")+" svelte-12bfisv")&&(R.className=x)},i:p,o:p,d(e){e&&i(t)}}}function A(e,t,s){let{segment:r}=t;return e.$set=(e=>{"segment"in e&&s("segment",r=e.segment)}),{segment:r}}class x extends e{constructor(e){super(),t(this,e,A,R,s,["segment"])}}function C(e){var t,s,n,f=new x({props:{segment:e.segment}});const p=e.$$slots.default,v=m(p,e,null);return{c(){f.$$.fragment.c(),t=a(),s=r("main"),v&&v.c()},l(e){f.$$.fragment.l(e),t=c(e,"\n\n"),s=o(e,"MAIN",{},!1);var r=l(s);v&&v.l(r),r.forEach(i)},m(e,r){h(f,e,r),u(e,t,r),u(e,s,r),v&&v.m(s,null),n=!0},p(e,t){var s={};e.segment&&(s.segment=t.segment),f.$set(s),v&&v.p&&e.$$scope&&v.p(g(p,t,e,null),d(p,t,null))},i(e){n||(f.$$.fragment.i(e),v&&v.i&&v.i(e),n=!0)},o(e){f.$$.fragment.o(e),v&&v.o&&v.o(e),n=!1},d(e){f.$destroy(e),e&&(i(t),i(s)),v&&v.d(e)}}}function j(e,t,s){let{segment:r}=t,{$$slots:n={},$$scope:a}=t;return e.$set=(e=>{"segment"in e&&s("segment",r=e.segment),"$$scope"in e&&s("$$scope",a=e.$$scope)}),{segment:r,$$slots:n,$$scope:a}}class q extends e{constructor(e){super(),t(this,e,j,C,s,["segment"])}}function U(e){var t,s,a=e.error.stack;return{c(){t=r("pre"),s=n(a)},l(e){t=o(e,"PRE",{},!1);var r=l(t);s=c(r,a),r.forEach(i)},m(e,r){u(e,t,r),f(t,s)},p(e,t){e.error&&a!==(a=t.error.stack)&&v(s,a)},d(e){e&&i(t)}}}function k(e){var t,s,m,h,g,d,b,y,E,S=e.error.message;document.title=t=e.status;var w=e.dev&&e.error.stack&&U(e);return{c(){s=a(),m=r("h1"),h=n(e.status),g=a(),d=r("p"),b=n(S),y=a(),w&&w.c(),E=$(),this.h()},l(t){s=c(t,"\n\n"),m=o(t,"H1",{class:!0},!1);var r=l(m);h=c(r,e.status),r.forEach(i),g=c(t,"\n\n"),d=o(t,"P",{class:!0},!1);var n=l(d);b=c(n,S),n.forEach(i),y=c(t,"\n\n"),w&&w.l(t),E=$(),this.h()},h(){m.className="svelte-8od9u6",d.className="svelte-8od9u6"},m(e,t){u(e,s,t),u(e,m,t),f(m,h),u(e,g,t),u(e,d,t),f(d,b),u(e,y,t),w&&w.m(e,t),u(e,E,t)},p(e,s){e.status&&t!==(t=s.status)&&(document.title=t),e.status&&v(h,s.status),e.error&&S!==(S=s.error.message)&&v(b,S),s.dev&&s.error.stack?w?w.p(e,s):((w=U(s)).c(),w.m(E.parentNode,E)):w&&(w.d(1),w=null)},i:p,o:p,d(e){e&&(i(s),i(m),i(g),i(d),i(y)),w&&w.d(e),e&&i(E)}}}function O(e,t,s){let{status:r,error:n}=t;return e.$set=(e=>{"status"in e&&s("status",r=e.status),"error"in e&&s("error",n=e.error)}),{status:r,error:n,dev:!1}}class I extends e{constructor(e){super(),t(this,e,O,k,s,["status","error"])}}function D(e){var t,s,r=[e.level1.props],n=e.level1.component;function a(e){let t={};for(var s=0;s<r.length;s+=1)t=b(t,r[s]);return{props:t}}if(n)var o=new n(a());return{c(){o&&o.$$.fragment.c(),t=$()},l(e){o&&o.$$.fragment.l(e),t=$()},m(e,r){o&&h(o,e,r),u(e,t,r),s=!0},p(e,s){var l=e.level1?y(r,[s.level1.props]):{};if(n!==(n=s.level1.component)){if(o){N();const e=o;S(()=>{e.$destroy()}),e.$$.fragment.o(1),w()}n?((o=new n(a())).$$.fragment.c(),o.$$.fragment.i(1),h(o,t.parentNode,t)):o=null}else n&&o.$set(l)},i(e){s||(o&&o.$$.fragment.i(e),s=!0)},o(e){o&&o.$$.fragment.o(e),s=!1},d(e){e&&i(t),o&&o.$destroy(e)}}}function H(e){var t,s=new I({props:{error:e.error,status:e.status}});return{c(){s.$$.fragment.c()},l(e){s.$$.fragment.l(e)},m(e,r){h(s,e,r),t=!0},p(e,t){var r={};e.error&&(r.error=t.error),e.status&&(r.status=t.status),s.$set(r)},i(e){t||(s.$$.fragment.i(e),t=!0)},o(e){s.$$.fragment.o(e),t=!1},d(e){s.$destroy(e)}}}function J(e){var t,s,r,n,a=[H,D],o=[];function l(e){return e.error?0:1}return t=l(e),s=o[t]=a[t](e),{c(){s.c(),r=$()},l(e){s.l(e),r=$()},m(e,s){o[t].m(e,s),u(e,r,s),n=!0},p(e,n){var c=t;(t=l(n))===c?o[t].p(e,n):(N(),S(()=>{o[c].d(1),o[c]=null}),s.o(1),w(),(s=o[t])||(s=o[t]=a[t](n)).c(),s.i(1),s.m(r.parentNode,r))},i(e){n||(s&&s.i(),n=!0)},o(e){s&&s.o(),n=!1},d(e){o[t].d(e),e&&i(r)}}}function V(e){var t,s=[{segment:e.segments[0]},e.level0.props];let r={$$slots:{default:[J]},$$scope:{ctx:e}};for(var n=0;n<s.length;n+=1)r=b(r,s[n]);var a=new q({props:r});return{c(){a.$$.fragment.c()},l(e){a.$$.fragment.l(e)},m(e,s){h(a,e,s),t=!0},p(e,t){var r=e.segments||e.level0?y(s,[e.segments&&{segment:t.segments[0]},e.level0&&t.level0.props]):{};(e.$$scope||e.error||e.status||e.level1)&&(r.$$scope={changed:e,ctx:t}),a.$set(r)},i(e){t||(a.$$.fragment.i(e),t=!0)},o(e){a.$$.fragment.o(e),t=!1},d(e){a.$destroy(e)}}}function B(e,t,s){let{stores:r,error:n,status:a,segments:o,level0:l,level1:c=null}=t;return E(L,r),e.$set=(e=>{"stores"in e&&s("stores",r=e.stores),"error"in e&&s("error",n=e.error),"status"in e&&s("status",a=e.status),"segments"in e&&s("segments",o=e.segments),"level0"in e&&s("level0",l=e.level0),"level1"in e&&s("level1",c=e.level1)}),{stores:r,error:n,status:a,segments:o,level0:l,level1:c}}class K extends e{constructor(e){super(),t(this,e,B,V,s,["stores","error","status","segments","level0","level1"])}}const T=[],G=[{js:()=>import("./index.e2f2bb52.js"),css:["index.e2f2bb52.css"]},{js:()=>import("./installing.0446bbb4.js"),css:[]},{js:()=>import("./using.29e817f8.js"),css:[]}],M=[{pattern:/^\/$/,parts:[{i:0}]},{pattern:/^\/installing\/?$/,parts:[{i:1}]},{pattern:/^\/using\/?$/,parts:[{i:2}]}];const W="undefined"!=typeof __SAPPER__&&__SAPPER__;let X,Y,z,F=!1,Q=[],Z="{}";const ee={page:_({}),preloading:_(null),session:_(W&&W.session)};let te,se;ee.session.subscribe(async e=>{if(te=e,!F)return;se=!0;const t=ue(new URL(location.href)),s=Y={},{redirect:r,props:n,branch:a}=await he(t);s===Y&&await me(r,a,n,t.page)});let re,ne=null;let ae,oe=1;const le="undefined"!=typeof history?history:{pushState:(e,t,s)=>{},replaceState:(e,t,s)=>{},scrollRestoration:""},ce={};function ie(e){const t=Object.create(null);return e.length>0&&e.slice(1).split("&").forEach(e=>{let[,s,r=""]=/([^=]*)(?:=(.*))?/.exec(decodeURIComponent(e.replace(/\+/g," ")));"string"==typeof t[s]&&(t[s]=[t[s]]),"object"==typeof t[s]?t[s].push(r):t[s]=r}),t}function ue(e){if(e.origin!==location.origin)return null;if(!e.pathname.startsWith(W.baseUrl))return null;let t=e.pathname.slice(W.baseUrl.length);if(""===t&&(t="/"),!T.some(e=>e.test(t)))for(let s=0;s<M.length;s+=1){const r=M[s],n=r.pattern.exec(t);if(n){const s=ie(e.search),a=r.parts[r.parts.length-1],o=a.params?a.params(n):{},l={path:t,query:s,params:o};return{href:e.href,route:r,match:n,page:l}}}}function fe(){return{x:pageXOffset,y:pageYOffset}}async function pe(e,t,s,r){if(t)ae=t;else{const e=fe();ce[ae]=e,t=ae=++oe,ce[ae]=s?e:{x:0,y:0}}ae=t,X&&ee.preloading.set(!0);const n=ne&&ne.href===e.href?ne.promise:he(e);ne=null;const a=Y={},{redirect:o,props:l,branch:c}=await n;if(a===Y&&(await me(o,c,l,e.page),document.activeElement&&document.activeElement.blur(),!s)){let e=ce[t];if(r){const t=document.getElementById(r.slice(1));t&&(e={x:0,y:t.getBoundingClientRect().top})}ce[ae]=e,e&&scrollTo(e.x,e.y)}}async function me(e,t,s,r){if(e)return function(e,t={replaceState:!1}){const s=ue(new URL(e,document.baseURI));return s?(le[t.replaceState?"replaceState":"pushState"]({id:ae},"",e),pe(s,null).then(()=>{})):(location.href=e,new Promise(e=>{}))}(e.location,{replaceState:!0});if(ee.page.set(r),ee.preloading.set(!1),X)X.$set(s);else{s.stores={page:{subscribe:ee.page.subscribe},preloading:{subscribe:ee.preloading.subscribe},session:ee.session},s.level0={props:await z};const e=document.querySelector("#sapper-head-start"),t=document.querySelector("#sapper-head-end");if(e&&t){for(;e.nextSibling!==t;)de(e.nextSibling);de(e),de(t)}X=new K({target:re,props:s,hydrate:!0})}Q=t,Z=JSON.stringify(r.query),F=!0,se=!1}async function he(e){const{route:t,page:s}=e,r=s.path.split("/").filter(Boolean);let n=null;const a={error:null,status:200,segments:[r[0]]},o={fetch:(e,t)=>fetch(e,t),redirect:(e,t)=>{if(n&&(n.statusCode!==e||n.location!==t))throw new Error("Conflicting redirects");n={statusCode:e,location:t}},error:(e,t)=>{a.error="string"==typeof t?new Error(t):t,a.status=e}};let l;z||(z=W.preloaded[0]||P.call(o,{path:s.path,query:s.query,params:{}},te));let c=1;try{const n=JSON.stringify(s.query),i=t.pattern.exec(s.path);let u=!1;l=await Promise.all(t.parts.map(async(t,l)=>{const f=r[l];if(function(e,t,s,r){if(r!==Z)return!0;const n=Q[e];return!!n&&(t!==n.segment||!(!n.match||JSON.stringify(n.match.slice(1,e+2))===JSON.stringify(s.slice(1,e+2)))||void 0)}(l,f,i,n)&&(u=!0),a.segments[c]=r[l+1],!t)return{segment:f};const p=c++;if(!se&&!u&&Q[l]&&Q[l].part===t.i)return Q[l];u=!1;const{default:m,preload:h}=await function(e){const t="string"==typeof e.css?[]:e.css.map(ge);return t.unshift(e.js()),Promise.all(t).then(e=>e[0])}(G[t.i]);let g;return g=F||!W.preloaded[l+1]?h?await h.call(o,{path:s.path,query:s.query,params:t.params?t.params(e.match):{}},te):{}:W.preloaded[l+1],a[`level${p}`]={component:m,props:g,segment:f,match:i,part:t.i}}))}catch(e){a.error=e,a.status=500,l=[]}return{redirect:n,props:a,branch:l}}function ge(e){const t=`client/${e}`;if(!document.querySelector(`link[href="${t}"]`))return new Promise((e,s)=>{const r=document.createElement("link");r.rel="stylesheet",r.href=t,r.onload=(()=>e()),r.onerror=s,document.head.appendChild(r)})}function de(e){e.parentNode.removeChild(e)}function ve(e){const t=ue(new URL(e,document.baseURI));if(t)return ne&&e===ne.href||function(e,t){ne={href:e,promise:t}}(e,he(t)),ne.promise}let $e;function be(e){clearTimeout($e),$e=setTimeout(()=>{ye(e)},20)}function ye(e){const t=Se(e.target);t&&"prefetch"===t.rel&&ve(t.href)}function Ee(e){if(1!==function(e){return null===e.which?e.button:e.which}(e))return;if(e.metaKey||e.ctrlKey||e.shiftKey)return;if(e.defaultPrevented)return;const t=Se(e.target);if(!t)return;if(!t.href)return;const s="object"==typeof t.href&&"SVGAnimatedString"===t.href.constructor.name,r=String(s?t.href.baseVal:t.href);if(r===location.href)return void(location.hash||e.preventDefault());if(t.hasAttribute("download")||"external"===t.getAttribute("rel"))return;if(s?t.target.baseVal:t.target)return;const n=new URL(r);if(n.pathname===location.pathname&&n.search===location.search)return;const a=ue(n);if(a){pe(a,null,t.hasAttribute("sapper-noscroll"),n.hash),e.preventDefault(),le.pushState({id:ae},"",n.href)}}function Se(e){for(;e&&"A"!==e.nodeName.toUpperCase();)e=e.parentNode;return e}function we(e){if(ce[ae]=fe(),e.state){const t=ue(new URL(location.href));t?pe(t,e.state.id):location.href=location.href}else(function(e){ae=e})(oe=oe+1),le.replaceState({id:ae},"",location.href)}!function(e){var t;"scrollRestoration"in le&&(le.scrollRestoration="manual"),t=e.target,re=t,addEventListener("click",Ee),addEventListener("popstate",we),addEventListener("touchstart",ye),addEventListener("mousemove",be),Promise.resolve().then(()=>{const{hash:e,href:t}=location;le.replaceState({id:oe},"",t);const s=new URL(location.href);if(W.error)return function(e){const{pathname:t,search:s}=location,{session:r,preloaded:n,status:a,error:o}=W;z||(z=n&&n[0]),me(null,[],{error:o,status:a,session:r,level0:{props:z},level1:{props:{status:a,error:o},component:I},segments:n},{path:t,query:ie(s),params:{}})}();const r=ue(s);return r?pe(r,oe,!0,e):void 0})}({target:document.querySelector("#sapper")});
//# sourceMappingURL=client.a596705a.js.map