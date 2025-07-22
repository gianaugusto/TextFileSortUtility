using System;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;

namespace TestFileCreator.Writing
{
    public class BufferedFileWriter : IFileWriter
    {
        private readonly StreamWriter _streamWriter;
        private readonly ArrayPool<char> _charPool;
        private char[] _buffer;
        private int _bufferPosition;
        private const int BufferSize = 8192;

        public BufferedFileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath, append: false) { AutoFlush = false };
            _charPool = ArrayPool<char>.Shared;
            _buffer = _charPool.Rent(BufferSize);
            _bufferPosition = 0;
        }

        public async Task WriteLineAsync(string line)
        {
            int lineLength = line.Length;

            // If the line is too long for the buffer, write it directly
            if (lineLength > BufferSize)
            {
                await _streamWriter.WriteLineAsync(line);
                return;
            }

            // Check if we need to flush the buffer first
            if (_bufferPosition + lineLength + 2 > BufferSize) // +2 for \r\n
            {
                await FlushAsync();
            }

            // Copy the line to the buffer
            line.CopyTo(0, _buffer, _bufferPosition, lineLength);
            _bufferPosition += lineLength;

            // Add the newline characters
            _buffer[_bufferPosition++] = '\r';
            _buffer[_bufferPosition++] = '\n';
        }

        public async Task FlushAsync()
        {
            if (_bufferPosition > 0)
            {
                await _streamWriter.WriteAsync(_buffer, 0, _bufferPosition);
                _bufferPosition = 0;
            }
            await _streamWriter.FlushAsync();
        }

        public void Dispose()
        {
            if (_buffer != null)
            {
                _charPool.Return(_buffer);
                _buffer = null;
            }

            _streamWriter?.Dispose();
        }
    }
}
