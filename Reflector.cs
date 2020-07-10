using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyProgram
{
    public class Reflector
    {
        public static bool IsTypeClass(string className)
        {
            Type myType = Type.GetType(className, false, true);
            return myType != null && myType.IsClass;
        }

        public static bool IsTypeClass(Type type)
        {            
            return type != null && type.IsClass;
        }

        public static bool HasTypeField(Type containerType, string fieldName, Type fieldType)
        {
            return containerType.GetField(fieldName, 
                BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static)
                ?.FieldType.Equals(fieldType) ?? false;
        }

        public static bool IsFieldPrivate(Type containerType, string memberName)
        { 
            return containerType.GetField(memberName, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                ?.IsPrivate ?? false; 
        }

        public static bool IsFieldProtected(Type containerType, string memberName)
        { 
            return containerType.GetField(memberName, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                ?.IsFamily ?? false; 
        }        
        
        public static bool IsFieldInternal(Type containerType, string memberName)
        { 
            return containerType.GetField(memberName, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) 
                ?.IsAssembly ?? false;
        }        
        
        public static bool IsFieldProtectedInternal(Type containerType, string memberName)
        {
            return containerType.GetField(memberName, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) 
                ?.IsFamilyOrAssembly ?? false;
        }
        public static bool IsFieldPrivateProtected(Type containerType, string memberName)
        {
            return containerType.GetField(memberName, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                ?.IsFamilyAndAssembly ?? false;
        }

        public static bool IsFieldPublic(Type containerType, string memberName)
        {
            return containerType.GetField(memberName, 
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static) != null;
        }

        public static bool IsMemberStatic(Type containerType, string memberName)
        {
            return containerType.GetMember(memberName, 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).Length > 0;
        }
        
        public static bool HasTypeConstructor(Type containerType, Type[] parameters)
        {
            return containerType.GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, 
                null, parameters, null) != null;
        }

        public static bool IsConstructorPublic(Type containerType, Type[] parameters)
        {
            return containerType.GetConstructor(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, 
                null, parameters, null) != null;
        }
        
        public static bool IsConstructorPrivate(Type containerType, Type[] parameters)
        {
            return containerType.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, 
                null, parameters, null)?.IsPrivate ?? false;
        }

        public static bool IsConstructorStatic(Type containerType, Type[] parameters)
        {
            return containerType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                null, parameters, null) != null;
        }

        public static bool HasTypeProperty(Type containerType, string propertyName, Type propertyType)
        {
            return containerType.GetProperty(propertyName, 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, 
                null, propertyType, new Type[0], null) != null;
        }

        public static bool IsPropertyPublic(Type containerType, string propertyName)
        {
            return containerType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static) != null;
        }

        public static bool HasPropertyGetter(Type containerType, string propertyName)
        {
            return (containerType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                ?.CanRead ?? false;
        }

        public static bool HasPropertySetter(Type containerType, string propertyName)
        {
            return (containerType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                ?.CanWrite ?? false;
        }
        public static bool IsPropertySetterInternal(Type containerType, string propertyName)
        {            
            return (containerType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                ?.SetMethod ?.IsAssembly ?? false;
        }
        
        public static bool IsPropertyGetterInternal(Type containerType, string propertyName)
        {
            return (containerType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                ?.GetMethod?.IsAssembly ?? false;
        }


        public static bool HasTypeDeclaredMethod(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly,
                null, parameterTypes, null) != null;
        }
        
        public static bool HasMethodReturnType(Type containerType, string methodName, Type[] parameterTypes, Type returnType)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly,
                null, parameterTypes, null)?.ReturnType.Equals(returnType) ?? false;
        }

        public static bool IsDeclaredMethodVirtual(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly,
                null, parameterTypes, null)?.IsVirtual ?? false;
        }

        public static bool HasTypeMethod(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null) != null;
        } 
        
        public static bool IsMethodPublic(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null) != null;
        }
        
        public static bool IsMethodProtected(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null)?.IsFamily ?? false;
        }

        public static bool IsMethodPrivate(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null)?.IsPrivate ?? false;
        }

        public static bool IsMethodInternal(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null)?.IsAssembly ?? false;
        }
        public static bool IsMethodProtectedInternal(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null)?.IsFamilyOrAssembly ?? false;
        }
        public static bool IsMethodPrivateProtected(Type containerType, string methodName, Type[] parameterTypes)
        {
            return containerType.GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                null, parameterTypes, null)?.IsFamilyAndAssembly ?? false;
        }
    }
}
