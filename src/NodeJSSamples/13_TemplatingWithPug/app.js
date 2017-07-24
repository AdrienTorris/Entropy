const pug = require('pug');

// Compile the source code
const compiledFunction = pug.compileFile('template.pug');

// Render a set of data
console.log(compiledFunction({
    text: 'This is a text'
}));

// Render another set of data
console.log(compiledFunction({
    text: 'This is another text'
}));

// Another rendering which provides some html
const htmlCompiledFunction= pug.compileFile('template2.pug');
console.log(htmlCompiledFunction({
    title: 'This is my title',
    pageTitle: 'This is my page title'
}));

var html = htmlCompiledFunction({
    title: 'This is my title',
    pageTitle: 'This is my page title'
});
console.log(html);