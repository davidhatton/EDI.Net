﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace indice.Edi.Serialization
{

    /// <summary>
    /// The type of an autogenerated value. Used in conjunction with <see cref="EdiGeneratedAttribute"/>.
    /// </summary>
    public enum EdiGeneratedType 
    {
        /// <summary>
        /// Gives the count of items. Its meaning is contextual and is related to the <seealso cref="EdiStructureType"/>.
        /// </summary>
        Count = 0,

        /// <summary>
        /// Gives the current position instide a container. Its meaning is contextual and is related to the <seealso cref="EdiStructureType"/>.
        /// </summary>
        Position = 1,

        /// <summary>
        /// Gives the current index instide a container. Its meaning is contextual and is related to the <seealso cref="EdiStructureType"/>.
        /// </summary>
        Index = 2,
    }

    /// <summary>
    /// Use <see cref="EdiGeneratedAttribute"/> for any value that the serializer should be generating. Usualy these are counts or indices.
    /// </summary>
    /// <remarks>Used in conjunction with <see cref="EdiValueAttribute"/>. Will be used only upon serialization.</remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class EdiGeneratedAttribute : EdiAttribute
    {
        private readonly EdiStructureType _Scope;
        private readonly EdiGeneratedType _Type;

        /// <summary>
        /// The type of an autogenerated value. Count, Position, Index
        /// </summary>
        public EdiGeneratedType Type {
            get { return _Type; }
        }

        /// <summary>
        /// The scope of the autogenerated value. <seealso cref="EdiStructureType"/>
        /// </summary>
        public EdiStructureType Scope { 
            get { return _Scope; }
        }

        /// <summary>
        /// Creates a <see cref="EdiGeneratedAttribute"/>. Marks a value that the serializer should be generating.
        /// </summary>
        /// <param name="type">The type of an autogenerated value. Count, Position, Index.</param>
        /// <param name="scope">The scope of the autogenerated value. Interchange, Message etc.</param>
        public EdiGeneratedAttribute(EdiGeneratedType type, EdiStructureType scope) {
            _Type = type;
            _Scope = scope;
        }

        /// <summary>
        /// String representation of <see cref="EdiGeneratedAttribute"/> settings.
        /// </summary>
        /// <returns>The string rerpesentation</returns>
        public override string ToString() {
            string stopWord;
            switch (Type) {
                case EdiGeneratedType.Count: stopWord = "of"; break;
                case EdiGeneratedType.Position: stopWord = "in"; break;
                case EdiGeneratedType.Index: stopWord = "in"; break;
                default: stopWord = string.Empty; break;
            }
            return $"{Type} {stopWord} {Scope}";
        }
    }
}