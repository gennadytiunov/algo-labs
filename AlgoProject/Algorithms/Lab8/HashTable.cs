using System;

namespace Otus.AlgoLabs.Algorithms.Lab8
{
	public class HashTable<K, V> where V : class
	{
		private const double FillFactor = 0.75;
		private const int GrowthFactor = 2;
		private const int InitialArrayLength = 4;

		private int _nodeCount;

		private Node<K,V>[] _values = new Node<K, V>[InitialArrayLength];

		public void Put(K key, V value)
		{
			var index = Hash(key, _values.Length);

			var nodeList = _values[index];
			if (nodeList == null)
			{
				_values[index] = new Node<K, V>(key, value);
				_nodeCount++;
			}
			else
			{
				var existingNode = Find(key);
				if (existingNode != null)
				{
					//Console.WriteLine($"Put: Element with key '{key}' already exists, value '{existingNode.Value}' has been replaced by '{value}'.");
					existingNode.Value = value;
				}
				else
				{
					nodeList.Insert(new Node<K, V>(key, value));

					_nodeCount++;
					if (_nodeCount / (double) _values.Length >= FillFactor)
					{
						Rehash();
					}
				}
			}
		}

		public V Get(K key)
		{
			var node = Find(key);
			return node?.Value;
		}

		public V Delete(K key)
		{
			var index = Hash(key, _values.Length);

			var node = _values[index];
			if (node == null)
			{
				return null;
			}

			do
			{
				if (node.Key.Equals(key))
				{
					var removedValue = node.Value;

					if (node.Next != null)
					{
						node.Value = node.Next.Value;
						node.Next = node.Next.Next;
					}
					else
					{
						node = null;
					}

					return removedValue;
				}

				node = node.Next;
			}
			while (node != null);

			return null;
		}
		
		private Node<K,V> Find(K key)
		{
			var index = Hash(key, _values.Length);

			var node = _values[index];
			if (node == null)
			{
				return null;
			}

			do
			{
				if (node.Key.Equals(key))
				{
					return node;
				}

				node = node.Next;

			} while (node != null);

			return default;
		}
		
		private void Rehash()
		{
			var array = new Node<K, V>[_values.Length * GrowthFactor];

			foreach (var node in _values)
			{
				if (node != null)
				{
					RehashNode(array, node);
				}
			}

			_values = array;
		}

		private void RehashNode(Node<K,V>[] array, Node<K,V> node)
		{
			var nextOldNode = node.Next;
			node.Next = null;

			var index = Hash(node.Key, array.Length);

			var newList = array[index];
			if (newList == null)
			{
				array[index] = node;
			}
			else
			{
				newList.Insert(node);
			}

			if (nextOldNode != null)
			{
				RehashNode(array, nextOldNode);
			}
		}

		private int Hash(K key, int arrayLength)
		{
			var hashCode = key.GetHashCode();
			var hash = Math.Abs(hashCode) % arrayLength;
			AssertHashInRange(hash, arrayLength);
			return hash;
		}

		private void AssertHashInRange(int hash, int arrayLength)
		{
			if (hash > arrayLength - 1)
			{
				throw new ArgumentOutOfRangeException($"AssertHashInRange: hash value '{nameof(hash)}' is out of range '0 - {arrayLength}'.");
			}
		}

		private class Node<K, V>
		{
			public K Key { get; }

			public V Value { get; set; }

			public Node<K, V> Next { get; set; }

			public Node(K key, V value)
			{
				Key = key;
				Value = value;
				Next = null;
			}

			public void Append(Node<K,V> node)
			{
				Next = node ?? throw new InvalidOperationException("Node:Append: Cannot append empty node.");
			}

			public void Insert(Node<K, V> node)
			{
				if (node == null)
				{
					throw new InvalidOperationException("Node:Insert: Cannot insert empty node.");
				}

				if (Next == null)
				{
					Append(node);
				}
				else
				{
					node.Next = Next;
					Next = node;
				}
			}

			public Node<K, V> GetLast()
			{
				var last = this;
				while (last.Next != null)
				{
					last = last.Next;
				}
				return last;
			}
		}
	}
}