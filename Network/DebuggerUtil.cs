/*
  Copyright (C) 2009 Volker Berlin (vberlin@inetsoftware.de)

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Jeroen Frijters
  jeroen@frijters.net

*/

using System.IO;

namespace Consulo.Internal.Mssdw.Network
{
	class DebuggerUtil
	{
		/// <summary>
		/// Read the buffer full.
		/// </summary>
		/// <param name="stream">the stream to read</param>
		/// <param name="buffer">the buffer that should be fill</param>
		/// <exception cref="EndOfStreamException">
		/// If the stream ends.
		/// </exception>
		internal static void ReadFully(Stream stream, byte[] buffer)
		{
			int offset = 0;
			int needed = buffer.Length;
			while (needed > 0)
			{
				int count = stream.Read(buffer, offset, needed - offset);
				if (count == 0)
				{
					throw new EndOfStreamException();
				}
				needed -= count;
				offset += count;
			}
		}
	}
}