import{a as t,b as e,c as r,d as n,e as a,f as o,g as s,h as i,i as c,j as u,k as l,l as f,m as p,n as h,o as m,p as v,q as g,r as d,s as y,t as $,u as w,v as b,w as x,x as E,y as L,z as S,A as _,B as N,C as k,D as P,E as A}from"./chunk.29b24804.js";import{a as q,b as R}from"./chunk.606f9ac3.js";function j(t,e){return function(t){if(Array.isArray(t))return t}(t)||function(t,e){var r=[],n=!0,a=!1,o=void 0;try{for(var s,i=t[Symbol.iterator]();!(n=(s=i.next()).done)&&(r.push(s.value),!e||r.length!==e);n=!0);}catch(t){a=!0,o=t}finally{try{n||null==i.return||i.return()}finally{if(a)throw o}}return r}(t,e)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}var O,C=(function(e){var r=function(e){var r,n=Object.prototype,a=n.hasOwnProperty,o="function"==typeof Symbol?Symbol:{},s=o.iterator||"@@iterator",i=o.asyncIterator||"@@asyncIterator",c=o.toStringTag||"@@toStringTag";function u(t,e,r,n){var a=e&&e.prototype instanceof g?e:g,o=Object.create(a.prototype),s=new k(n||[]);return o._invoke=function(t,e,r){var n=f;return function(a,o){if(n===h)throw new Error("Generator is already running");if(n===m){if("throw"===a)throw o;return A()}for(r.method=a,r.arg=o;;){var s=r.delegate;if(s){var i=S(s,r);if(i){if(i===v)continue;return i}}if("next"===r.method)r.sent=r._sent=r.arg;else if("throw"===r.method){if(n===f)throw n=m,r.arg;r.dispatchException(r.arg)}else"return"===r.method&&r.abrupt("return",r.arg);n=h;var c=l(t,e,r);if("normal"===c.type){if(n=r.done?m:p,c.arg===v)continue;return{value:c.arg,done:r.done}}"throw"===c.type&&(n=m,r.method="throw",r.arg=c.arg)}}}(t,r,s),o}function l(t,e,r){try{return{type:"normal",arg:t.call(e,r)}}catch(t){return{type:"throw",arg:t}}}e.wrap=u;var f="suspendedStart",p="suspendedYield",h="executing",m="completed",v={};function g(){}function d(){}function y(){}var $={};$[s]=function(){return this};var w=Object.getPrototypeOf,b=w&&w(w(P([])));b&&b!==n&&a.call(b,s)&&($=b);var x=y.prototype=g.prototype=Object.create($);function E(t){["next","throw","return"].forEach(function(e){t[e]=function(t){return this._invoke(e,t)}})}function L(e){var r;this._invoke=function(n,o){function s(){return new Promise(function(r,s){!function r(n,o,s,i){var c=l(e[n],e,o);if("throw"!==c.type){var u=c.arg,f=u.value;return f&&"object"===t(f)&&a.call(f,"__await")?Promise.resolve(f.__await).then(function(t){r("next",t,s,i)},function(t){r("throw",t,s,i)}):Promise.resolve(f).then(function(t){u.value=t,s(u)},function(t){return r("throw",t,s,i)})}i(c.arg)}(n,o,r,s)})}return r=r?r.then(s,s):s()}}function S(t,e){var n=t.iterator[e.method];if(n===r){if(e.delegate=null,"throw"===e.method){if(t.iterator.return&&(e.method="return",e.arg=r,S(t,e),"throw"===e.method))return v;e.method="throw",e.arg=new TypeError("The iterator does not provide a 'throw' method")}return v}var a=l(n,t.iterator,e.arg);if("throw"===a.type)return e.method="throw",e.arg=a.arg,e.delegate=null,v;var o=a.arg;return o?o.done?(e[t.resultName]=o.value,e.next=t.nextLoc,"return"!==e.method&&(e.method="next",e.arg=r),e.delegate=null,v):o:(e.method="throw",e.arg=new TypeError("iterator result is not an object"),e.delegate=null,v)}function _(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function N(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function k(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(_,this),this.reset(!0)}function P(t){if(t){var e=t[s];if(e)return e.call(t);if("function"==typeof t.next)return t;if(!isNaN(t.length)){var n=-1,o=function e(){for(;++n<t.length;)if(a.call(t,n))return e.value=t[n],e.done=!1,e;return e.value=r,e.done=!0,e};return o.next=o}}return{next:A}}function A(){return{value:r,done:!0}}return d.prototype=x.constructor=y,y.constructor=d,y[c]=d.displayName="GeneratorFunction",e.isGeneratorFunction=function(t){var e="function"==typeof t&&t.constructor;return!!e&&(e===d||"GeneratorFunction"===(e.displayName||e.name))},e.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,y):(t.__proto__=y,c in t||(t[c]="GeneratorFunction")),t.prototype=Object.create(x),t},e.awrap=function(t){return{__await:t}},E(L.prototype),L.prototype[i]=function(){return this},e.AsyncIterator=L,e.async=function(t,r,n,a){var o=new L(u(t,r,n,a));return e.isGeneratorFunction(r)?o:o.next().then(function(t){return t.done?t.value:o.next()})},E(x),x[c]="Generator",x[s]=function(){return this},x.toString=function(){return"[object Generator]"},e.keys=function(t){var e=[];for(var r in t)e.push(r);return e.reverse(),function r(){for(;e.length;){var n=e.pop();if(n in t)return r.value=n,r.done=!1,r}return r.done=!0,r}},e.values=P,k.prototype={constructor:k,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=r,this.done=!1,this.delegate=null,this.method="next",this.arg=r,this.tryEntries.forEach(N),!t)for(var e in this)"t"===e.charAt(0)&&a.call(this,e)&&!isNaN(+e.slice(1))&&(this[e]=r)},stop:function(){this.done=!0;var t=this.tryEntries[0].completion;if("throw"===t.type)throw t.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var e=this;function n(n,a){return i.type="throw",i.arg=t,e.next=n,a&&(e.method="next",e.arg=r),!!a}for(var o=this.tryEntries.length-1;o>=0;--o){var s=this.tryEntries[o],i=s.completion;if("root"===s.tryLoc)return n("end");if(s.tryLoc<=this.prev){var c=a.call(s,"catchLoc"),u=a.call(s,"finallyLoc");if(c&&u){if(this.prev<s.catchLoc)return n(s.catchLoc,!0);if(this.prev<s.finallyLoc)return n(s.finallyLoc)}else if(c){if(this.prev<s.catchLoc)return n(s.catchLoc,!0)}else{if(!u)throw new Error("try statement without catch or finally");if(this.prev<s.finallyLoc)return n(s.finallyLoc)}}}},abrupt:function(t,e){for(var r=this.tryEntries.length-1;r>=0;--r){var n=this.tryEntries[r];if(n.tryLoc<=this.prev&&a.call(n,"finallyLoc")&&this.prev<n.finallyLoc){var o=n;break}}o&&("break"===t||"continue"===t)&&o.tryLoc<=e&&e<=o.finallyLoc&&(o=null);var s=o?o.completion:{};return s.type=t,s.arg=e,o?(this.method="next",this.next=o.finallyLoc,v):this.complete(s)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),v},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.finallyLoc===t)return this.complete(r.completion,r.afterLoc),N(r),v}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.tryLoc===t){var n=r.completion;if("throw"===n.type){var a=n.arg;N(r)}return a}}throw new Error("illegal catch attempt")},delegateYield:function(t,e,n){return this.delegate={iterator:P(t),resultName:e,nextLoc:n},"next"===this.method&&(this.arg=r),v}},e}(e.exports);try{regeneratorRuntime=r}catch(t){Function("r","regeneratorRuntime = r")(r)}}(O={exports:{}},O.exports),O.exports);function I(t,e,r,n,a,o,s){try{var i=t[o](s),c=i.value}catch(t){return void r(t)}i.done?e(c):Promise.resolve(c).then(n,a)}function U(t){return function(){var e=this,r=arguments;return new Promise(function(n,a){var o=t.apply(e,r);function s(t){I(o,n,a,s,i,"next",t)}function i(t){I(o,n,a,s,i,"throw",t)}s(void 0)})}}var T={},G=function(){return{}};function z(t){var e,r,n,a,o,s,i,c,$,w,b,x,E,L,S,_,N,k,P,A,R,j,O,C,I,U,T,G,z,D=new q({props:{name:"L E",size:"minuscule"}}),F=new q({props:{name:"T T",size:"minuscule"}}),V=new q({props:{name:"E R",size:"minuscule"}}),B=new q({props:{name:"A V",size:"minuscule"}}),H=new q({props:{name:"A T",size:"minuscule"}}),J=new q({props:{name:"A R",size:"minuscule"}}),K=new q({props:{name:"S",size:"minuscule"}});return{c:function(){e=u("nav"),r=u("ul"),n=u("li"),a=u("span"),o=l("Letter Avatar Service"),s=f(),i=u("li"),c=u("a"),$=l("home"),b=f(),x=u("li"),E=u("a"),L=l("installing"),_=f(),N=u("li"),k=u("a"),P=l("using"),R=f(),j=u("div"),D.$$.fragment.c(),O=f(),F.$$.fragment.c(),C=f(),V.$$.fragment.c(),I=f(),B.$$.fragment.c(),U=f(),H.$$.fragment.c(),T=f(),J.$$.fragment.c(),G=f(),K.$$.fragment.c(),this.h()},l:function(t){e=p(t,"NAV",{class:!0},!1);var u=h(e);r=p(u,"UL",{class:!0},!1);var l=h(r);n=p(l,"LI",{class:!0},!1);var f=h(n);a=p(f,"SPAN",{class:!0},!1);var g=h(a);o=m(g,"Letter Avatar Service"),g.forEach(v),f.forEach(v),s=m(l,"\n    "),i=p(l,"LI",{class:!0},!1);var d=h(i);c=p(d,"A",{class:!0,href:!0},!1);var y=h(c);$=m(y,"home"),y.forEach(v),d.forEach(v),b=m(l,"\n    "),x=p(l,"LI",{class:!0},!1);var w=h(x);E=p(w,"A",{class:!0,href:!0},!1);var S=h(E);L=m(S,"installing"),S.forEach(v),w.forEach(v),_=m(l,"\n    "),N=p(l,"LI",{class:!0},!1);var A=h(N);k=p(A,"A",{class:!0,href:!0},!1);var q=h(k);P=m(q,"using"),q.forEach(v),A.forEach(v),l.forEach(v),R=m(u,"\n  "),j=p(u,"DIV",{class:!0},!1);var z=h(j);D.$$.fragment.l(z),O=m(z,"\n    "),F.$$.fragment.l(z),C=m(z,"\n    "),V.$$.fragment.l(z),I=m(z,"\n    "),B.$$.fragment.l(z),U=m(z,"\n    "),H.$$.fragment.l(z),T=m(z,"\n    "),J.$$.fragment.l(z),G=m(z,"\n    "),K.$$.fragment.l(z),z.forEach(v),u.forEach(v),this.h()},h:function(){a.className="svelte-19qd0s",n.className="brand svelte-19qd0s",c.className=w=(void 0===t.segment?"selected":"")+" svelte-19qd0s",c.href=".",i.className="svelte-19qd0s",E.className=S=("installing"===t.segment?"selected":"")+" svelte-19qd0s",E.href="installing",x.className="svelte-19qd0s",k.className=A=("using"===t.segment?"selected":"")+" svelte-19qd0s",k.href="using",N.className="svelte-19qd0s",r.className="svelte-19qd0s",j.className="letter-logo svelte-19qd0s",e.className="svelte-19qd0s"},m:function(t,u){g(t,e,u),d(e,r),d(r,n),d(n,a),d(a,o),d(r,s),d(r,i),d(i,c),d(c,$),d(r,b),d(r,x),d(x,E),d(E,L),d(r,_),d(r,N),d(N,k),d(k,P),d(e,R),d(e,j),y(D,j,null),d(j,O),y(F,j,null),d(j,C),y(V,j,null),d(j,I),y(B,j,null),d(j,U),y(H,j,null),d(j,T),y(J,j,null),d(j,G),y(K,j,null),z=!0},p:function(t,e){z&&!t.segment||w===(w=(void 0===e.segment?"selected":"")+" svelte-19qd0s")||(c.className=w),z&&!t.segment||S===(S=("installing"===e.segment?"selected":"")+" svelte-19qd0s")||(E.className=S),z&&!t.segment||A===(A=("using"===e.segment?"selected":"")+" svelte-19qd0s")||(k.className=A)},i:function(t){z||(D.$$.fragment.i(t),F.$$.fragment.i(t),V.$$.fragment.i(t),B.$$.fragment.i(t),H.$$.fragment.i(t),J.$$.fragment.i(t),K.$$.fragment.i(t),z=!0)},o:function(t){D.$$.fragment.o(t),F.$$.fragment.o(t),V.$$.fragment.o(t),B.$$.fragment.o(t),H.$$.fragment.o(t),J.$$.fragment.o(t),K.$$.fragment.o(t),z=!1},d:function(t){t&&v(e),D.$destroy(),F.$destroy(),V.$destroy(),B.$destroy(),H.$destroy(),J.$destroy(),K.$destroy()}}}function D(t,e,r){var n=e.segment;return t.$set=function(t){"segment"in t&&r("segment",n=t.segment)},{segment:n}}var F=function(t){function u(t){var e;return r(this,u),e=n(this,a(u).call(this)),o(s(e),t,D,z,i,["segment"]),e}return e(u,c),u}();function V(t){var e,r,n,a=new F({props:{segment:t.segment}}),o=t.$$slots.default,s=$(o,t,null);return{c:function(){a.$$.fragment.c(),e=f(),r=u("main"),s&&s.c()},l:function(t){a.$$.fragment.l(t),e=m(t,"\n\n"),r=p(t,"MAIN",{},!1);var n=h(r);s&&s.l(n),n.forEach(v)},m:function(t,o){y(a,t,o),g(t,e,o),g(t,r,o),s&&s.m(r,null),n=!0},p:function(t,e){var r={};t.segment&&(r.segment=e.segment),a.$set(r),s&&s.p&&t.$$scope&&s.p(w(o,e,t,null),b(o,e,null))},i:function(t){n||(a.$$.fragment.i(t),s&&s.i&&s.i(t),n=!0)},o:function(t){a.$$.fragment.o(t),s&&s.o&&s.o(t),n=!1},d:function(t){a.$destroy(t),t&&(v(e),v(r)),s&&s.d(t)}}}function B(t,e,r){var n=e.segment,a=e.$$slots,o=void 0===a?{}:a,s=e.$$scope;return t.$set=function(t){"segment"in t&&r("segment",n=t.segment),"$$scope"in t&&r("$$scope",s=t.$$scope)},{segment:n,$$slots:o,$$scope:s}}var H=function(t){function u(t){var e;return r(this,u),e=n(this,a(u).call(this)),o(s(e),t,B,V,i,["segment"]),e}return e(u,c),u}();function J(t){var e,r,n=t.error.stack;return{c:function(){e=u("pre"),r=l(n)},l:function(t){e=p(t,"PRE",{},!1);var a=h(e);r=m(a,n),a.forEach(v)},m:function(t,n){g(t,e,n),d(e,r)},p:function(t,e){t.error&&n!==(n=e.error.stack)&&x(r,n)},d:function(t){t&&v(e)}}}function K(t){var e,r,n,a,o,s,i,c,y,$=t.error.message;document.title=e=t.status;var w=t.dev&&t.error.stack&&J(t);return{c:function(){r=f(),n=u("h1"),a=l(t.status),o=f(),s=u("p"),i=l($),c=f(),w&&w.c(),y=E(),this.h()},l:function(e){r=m(e,"\n\n"),n=p(e,"H1",{class:!0},!1);var u=h(n);a=m(u,t.status),u.forEach(v),o=m(e,"\n\n"),s=p(e,"P",{class:!0},!1);var l=h(s);i=m(l,$),l.forEach(v),c=m(e,"\n\n"),w&&w.l(e),y=E(),this.h()},h:function(){n.className="svelte-8od9u6",s.className="svelte-8od9u6"},m:function(t,e){g(t,r,e),g(t,n,e),d(n,a),g(t,o,e),g(t,s,e),d(s,i),g(t,c,e),w&&w.m(t,e),g(t,y,e)},p:function(t,r){t.status&&e!==(e=r.status)&&(document.title=e),t.status&&x(a,r.status),t.error&&$!==($=r.error.message)&&x(i,$),r.dev&&r.error.stack?w?w.p(t,r):((w=J(r)).c(),w.m(y.parentNode,y)):w&&(w.d(1),w=null)},i:L,o:L,d:function(t){t&&(v(r),v(n),v(o),v(s),v(c)),w&&w.d(t),t&&v(y)}}}function Y(t,e,r){var n=e.status,a=e.error;return t.$set=function(t){"status"in t&&r("status",n=t.status),"error"in t&&r("error",a=t.error)},{status:n,error:a,dev:!1}}var M=function(t){function u(t){var e;return r(this,u),e=n(this,a(u).call(this)),o(s(e),t,Y,K,i,["status","error"]),e}return e(u,c),u}();function W(t){var e,r,n=[t.level1.props],a=t.level1.component;function o(t){for(var e={},r=0;r<n.length;r+=1)e=S(e,n[r]);return{props:e}}if(a)var s=new a(o());return{c:function(){s&&s.$$.fragment.c(),e=E()},l:function(t){s&&s.$$.fragment.l(t),e=E()},m:function(t,n){s&&y(s,t,n),g(t,e,n),r=!0},p:function(t,r){var i=t.level1?_(n,[r.level1.props]):{};if(a!==(a=r.level1.component)){if(s){A();var c=s;k(function(){c.$destroy()}),c.$$.fragment.o(1),P()}a?((s=new a(o())).$$.fragment.c(),s.$$.fragment.i(1),y(s,e.parentNode,e)):s=null}else a&&s.$set(i)},i:function(t){r||(s&&s.$$.fragment.i(t),r=!0)},o:function(t){s&&s.$$.fragment.o(t),r=!1},d:function(t){t&&v(e),s&&s.$destroy(t)}}}function X(t){var e,r=new M({props:{error:t.error,status:t.status}});return{c:function(){r.$$.fragment.c()},l:function(t){r.$$.fragment.l(t)},m:function(t,n){y(r,t,n),e=!0},p:function(t,e){var n={};t.error&&(n.error=e.error),t.status&&(n.status=e.status),r.$set(n)},i:function(t){e||(r.$$.fragment.i(t),e=!0)},o:function(t){r.$$.fragment.o(t),e=!1},d:function(t){r.$destroy(t)}}}function Q(t){var e,r,n,a,o=[X,W],s=[];function i(t){return t.error?0:1}return e=i(t),r=s[e]=o[e](t),{c:function(){r.c(),n=E()},l:function(t){r.l(t),n=E()},m:function(t,r){s[e].m(t,r),g(t,n,r),a=!0},p:function(t,a){var c=e;(e=i(a))===c?s[e].p(t,a):(A(),k(function(){s[c].d(1),s[c]=null}),r.o(1),P(),(r=s[e])||(r=s[e]=o[e](a)).c(),r.i(1),r.m(n.parentNode,n))},i:function(t){a||(r&&r.i(),a=!0)},o:function(t){r&&r.o(),a=!1},d:function(t){s[e].d(t),t&&v(n)}}}function Z(t){for(var e,r=[{segment:t.segments[0]},t.level0.props],n={$$slots:{default:[Q]},$$scope:{ctx:t}},a=0;a<r.length;a+=1)n=S(n,r[a]);var o=new H({props:n});return{c:function(){o.$$.fragment.c()},l:function(t){o.$$.fragment.l(t)},m:function(t,r){y(o,t,r),e=!0},p:function(t,e){var n=t.segments||t.level0?_(r,[t.segments&&{segment:e.segments[0]},t.level0&&e.level0.props]):{};(t.$$scope||t.error||t.status||t.level1)&&(n.$$scope={changed:t,ctx:e}),o.$set(n)},i:function(t){e||(o.$$.fragment.i(t),e=!0)},o:function(t){o.$$.fragment.o(t),e=!1},d:function(t){o.$destroy(t)}}}function tt(t,e,r){var n=e.stores,a=e.error,o=e.status,s=e.segments,i=e.level0,c=e.level1,u=void 0===c?null:c;return N(T,n),t.$set=function(t){"stores"in t&&r("stores",n=t.stores),"error"in t&&r("error",a=t.error),"status"in t&&r("status",o=t.status),"segments"in t&&r("segments",s=t.segments),"level0"in t&&r("level0",i=t.level0),"level1"in t&&r("level1",u=t.level1)},{stores:n,error:a,status:o,segments:s,level0:i,level1:u}}var et=function(t){function u(t){var e;return r(this,u),e=n(this,a(u).call(this)),o(s(e),t,tt,Z,i,["stores","error","status","segments","level0","level1"]),e}return e(u,c),u}(),rt=[],nt=[{js:function(){return import("./index.7dd62de5.js")},css:["index.7dd62de5.css","chunk.606f9ac3.css"]},{js:function(){return import("./installing.7dc3eee2.js")},css:[]},{js:function(){return import("./using.f2ee38e0.js")},css:[]}],at=[{pattern:/^\/$/,parts:[{i:0}]},{pattern:/^\/installing\/?$/,parts:[{i:1}]},{pattern:/^\/using\/?$/,parts:[{i:2}]}];function ot(t){var e=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{replaceState:!1},r=Lt(new URL(t,document.baseURI));return r?(bt[e.replaceState?"replaceState":"pushState"]({id:yt},"",t),_t(r,null).then(function(){})):(location.href=t,new Promise(function(t){}))}var st,it,ct,ut,lt,ft="undefined"!=typeof __SAPPER__&&__SAPPER__,pt=!1,ht=[],mt="{}",vt={page:R({}),preloading:R(null),session:R(ft&&ft.session)};vt.session.subscribe(function(){var t=U(C.mark(function t(e){var r,n,a,o,s,i;return C.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:if(ut=e,pt){t.next=3;break}return t.abrupt("return");case 3:return lt=!0,r=Lt(new URL(location.href)),n=it={},t.next=8,qt(r);case 8:if(a=t.sent,o=a.redirect,s=a.props,i=a.branch,n===it){t.next=14;break}return t.abrupt("return");case 14:return t.next=16,kt(o,i,s,r.page);case 16:case"end":return t.stop()}},t)}));return function(e){return t.apply(this,arguments)}}());var gt,dt=null;var yt,$t=1;var wt,bt="undefined"!=typeof history?history:{pushState:function(t,e,r){},replaceState:function(t,e,r){},scrollRestoration:""},xt={};function Et(e){var r=Object.create(null);return e.length>0&&e.slice(1).split("&").forEach(function(e){var n=j(/([^=]*)(?:=(.*))?/.exec(decodeURIComponent(e.replace(/\+/g," "))),3),a=n[1],o=n[2],s=void 0===o?"":o;"string"==typeof r[a]&&(r[a]=[r[a]]),"object"===t(r[a])?r[a].push(s):r[a]=s}),r}function Lt(t){if(t.origin!==location.origin)return null;if(!t.pathname.startsWith(ft.baseUrl))return null;var e=t.pathname.slice(ft.baseUrl.length);if(""===e&&(e="/"),!rt.some(function(t){return t.test(e)}))for(var r=0;r<at.length;r+=1){var n=at[r],a=n.pattern.exec(e);if(a){var o=Et(t.search),s=n.parts[n.parts.length-1],i=s.params?s.params(a):{},c={path:e,query:o,params:i};return{href:t.href,route:n,match:a,page:c}}}}function St(){return{x:pageXOffset,y:pageYOffset}}function _t(t,e,r,n){return Nt.apply(this,arguments)}function Nt(){return(Nt=U(C.mark(function t(e,r,n,a){var o,s,i,c,u,l,f,p,h;return C.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return r?yt=r:(o=St(),xt[yt]=o,r=yt=++$t,xt[yt]=n?o:{x:0,y:0}),yt=r,st&&vt.preloading.set(!0),s=dt&&dt.href===e.href?dt.promise:qt(e),dt=null,i=it={},t.next=8,s;case 8:if(c=t.sent,u=c.redirect,l=c.props,f=c.branch,i===it){t.next=14;break}return t.abrupt("return");case 14:return t.next=16,kt(u,f,l,e.page);case 16:document.activeElement&&document.activeElement.blur(),n||(p=xt[r],a&&(h=document.getElementById(a.slice(1)))&&(p={x:0,y:h.getBoundingClientRect().top}),xt[yt]=p,p&&scrollTo(p.x,p.y));case 18:case"end":return t.stop()}},t)}))).apply(this,arguments)}function kt(t,e,r,n){return Pt.apply(this,arguments)}function Pt(){return(Pt=U(C.mark(function t(e,r,n,a){var o,s;return C.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:if(!e){t.next=2;break}return t.abrupt("return",ot(e.location,{replaceState:!0}));case 2:if(vt.page.set(a),vt.preloading.set(!1),!st){t.next=8;break}st.$set(n),t.next=17;break;case 8:return n.stores={page:{subscribe:vt.page.subscribe},preloading:{subscribe:vt.preloading.subscribe},session:vt.session},t.next=11,ct;case 11:if(t.t0=t.sent,n.level0={props:t.t0},o=document.querySelector("#sapper-head-start"),s=document.querySelector("#sapper-head-end"),o&&s){for(;o.nextSibling!==s;)Ct(o.nextSibling);Ct(o),Ct(s)}st=new et({target:gt,props:n,hydrate:!0});case 17:ht=r,mt=JSON.stringify(a.query),pt=!0,lt=!1;case 21:case"end":return t.stop()}},t)}))).apply(this,arguments)}function At(t,e,r,n){if(n!==mt)return!0;var a=ht[t];return!!a&&(e!==a.segment||(!(!a.match||JSON.stringify(a.match.slice(1,t+2))===JSON.stringify(r.slice(1,t+2)))||void 0))}function qt(t){return Rt.apply(this,arguments)}function Rt(){return(Rt=U(C.mark(function t(e){var r,n,a,o,s,i,c,u,l,f,p;return C.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return r=e.route,n=e.page,a=n.path.split("/").filter(Boolean),o=null,s={error:null,status:200,segments:[a[0]]},i={fetch:function(t){function e(e,r){return t.apply(this,arguments)}return e.toString=function(){return t.toString()},e}(function(t,e){return fetch(t,e)}),redirect:function(t,e){if(o&&(o.statusCode!==t||o.location!==e))throw new Error("Conflicting redirects");o={statusCode:t,location:e}},error:function(t,e){s.error="string"==typeof e?new Error(e):e,s.status=t}},ct||(ct=ft.preloaded[0]||G.call(i,{path:n.path,query:n.query,params:{}},ut)),u=1,t.prev=7,l=JSON.stringify(n.query),f=r.pattern.exec(n.path),p=!1,t.next=13,Promise.all(r.parts.map(function(){var t=U(C.mark(function t(r,o){var c,h,m,v,g,d;return C.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:if(c=a[o],At(o,c,f,l)&&(p=!0),s.segments[u]=a[o+1],r){t.next=5;break}return t.abrupt("return",{segment:c});case 5:if(h=u++,lt||p||!ht[o]||ht[o].part!==r.i){t.next=8;break}return t.abrupt("return",ht[o]);case 8:return p=!1,t.next=11,Ot(nt[r.i]);case 11:if(m=t.sent,v=m.default,g=m.preload,!pt&&ft.preloaded[o+1]){t.next=25;break}if(!g){t.next=21;break}return t.next=18,g.call(i,{path:n.path,query:n.query,params:r.params?r.params(e.match):{}},ut);case 18:t.t0=t.sent,t.next=22;break;case 21:t.t0={};case 22:d=t.t0,t.next=26;break;case 25:d=ft.preloaded[o+1];case 26:return t.abrupt("return",s["level".concat(h)]={component:v,props:d,segment:c,match:f,part:r.i});case 27:case"end":return t.stop()}},t)}));return function(e,r){return t.apply(this,arguments)}}()));case 13:c=t.sent,t.next=21;break;case 16:t.prev=16,t.t0=t.catch(7),s.error=t.t0,s.status=500,c=[];case 21:return t.abrupt("return",{redirect:o,props:s,branch:c});case 22:case"end":return t.stop()}},t,null,[[7,16]])}))).apply(this,arguments)}function jt(t){var e="client/".concat(t);if(!document.querySelector('link[href="'.concat(e,'"]')))return new Promise(function(t,r){var n=document.createElement("link");n.rel="stylesheet",n.href=e,n.onload=function(){return t()},n.onerror=r,document.head.appendChild(n)})}function Ot(t){var e="string"==typeof t.css?[]:t.css.map(jt);return e.unshift(t.js()),Promise.all(e).then(function(t){return t[0]})}function Ct(t){t.parentNode.removeChild(t)}function It(t){var e=Lt(new URL(t,document.baseURI));if(e)return dt&&t===dt.href||function(t,e){dt={href:t,promise:e}}(t,qt(e)),dt.promise}function Ut(t){clearTimeout(wt),wt=setTimeout(function(){Tt(t)},20)}function Tt(t){var e=zt(t.target);e&&"prefetch"===e.rel&&It(e.href)}function Gt(e){if(1===function(t){return null===t.which?t.button:t.which}(e)&&!(e.metaKey||e.ctrlKey||e.shiftKey||e.defaultPrevented)){var r=zt(e.target);if(r&&r.href){var n="object"===t(r.href)&&"SVGAnimatedString"===r.href.constructor.name,a=String(n?r.href.baseVal:r.href);if(a!==location.href){if(!r.hasAttribute("download")&&"external"!==r.getAttribute("rel")&&(n?!r.target.baseVal:!r.target)){var o=new URL(a);if(o.pathname!==location.pathname||o.search!==location.search){var s=Lt(o);if(s)_t(s,null,r.hasAttribute("sapper-noscroll"),o.hash),e.preventDefault(),bt.pushState({id:yt},"",o.href)}}}else location.hash||e.preventDefault()}}}function zt(t){for(;t&&"A"!==t.nodeName.toUpperCase();)t=t.parentNode;return t}function Dt(t){if(xt[yt]=St(),t.state){var e=Lt(new URL(location.href));e?_t(e,t.state.id):location.href=location.href}else(function(t){yt=t})($t=$t+1),bt.replaceState({id:yt},"",location.href)}!function(t){var e;"scrollRestoration"in bt&&(bt.scrollRestoration="manual"),e=t.target,gt=e,addEventListener("click",Gt),addEventListener("popstate",Dt),addEventListener("touchstart",Tt),addEventListener("mousemove",Ut),Promise.resolve().then(function(){var t=location,e=t.hash,r=t.href;bt.replaceState({id:$t},"",r);var n,a,o,s,i,c,u,l=new URL(location.href);if(ft.error)return n=location,a=n.pathname,o=n.search,s=ft.session,i=ft.preloaded,c=ft.status,u=ft.error,ct||(ct=i&&i[0]),void kt(null,[],{error:u,status:c,session:s,level0:{props:ct},level1:{props:{status:c,error:u},component:M},segments:i},{path:a,query:Et(o),params:{}});var f=Lt(l);return f?_t(f,$t,!0,e):void 0})}({target:document.querySelector("#sapper")});
//# sourceMappingURL=client.3855cd60.js.map
