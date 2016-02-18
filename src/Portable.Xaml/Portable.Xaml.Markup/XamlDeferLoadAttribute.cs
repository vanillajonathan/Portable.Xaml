//
// Copyright (C) 2010 Novell Inc. http://novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections;
using System.Collections.Generic;
using Portable.Xaml.ComponentModel;
using System.Reflection;
using Portable.Xaml.Markup;
using Portable.Xaml.Schema;

namespace Portable.Xaml.Markup
{
	[AttributeUsageAttribute(AttributeTargets.Class|AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class XamlDeferLoadAttribute : Attribute
	{
		Type contentType;
		Type loaderType;

		public XamlDeferLoadAttribute (string loaderType, string contentType)
		{
			if (loaderType == null)
				throw new ArgumentNullException(nameof(loaderType));
			if (contentType == null)
				throw new ArgumentNullException(nameof(contentType));
			LoaderTypeName = loaderType;
			ContentTypeName = contentType;
		}

		public XamlDeferLoadAttribute (Type loaderType, Type contentType)
		{
			if (loaderType == null)
				throw new ArgumentNullException(nameof(loaderType));
			if (contentType == null)
				throw new ArgumentNullException(nameof(contentType));
			this.loaderType = loaderType;
			LoaderTypeName = loaderType.AssemblyQualifiedName;
			this.contentType = contentType;
			ContentTypeName = contentType.AssemblyQualifiedName;
		}

		public Type ContentType
		{
			get
			{ 
				if (contentType == null && ContentTypeName != null)
					contentType = Type.GetType(ContentTypeName);
				return contentType; 
			}
		}

		public string ContentTypeName { get; private set; }

		public Type LoaderType
		{
			get
			{ 
				if (loaderType == null && LoaderTypeName != null)
					loaderType = Type.GetType(LoaderTypeName);
				return loaderType; 
			}
		}

		public string LoaderTypeName { get; private set; }

	}
}

