   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  '    !CVProject.Dialog.ArithmeticDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Arithmetic Operation��$	��169��$	��300�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ label��$��Image A��$
��Left=�$��	10,13,0,0q�$	��Top=��� -   $ 	lblImageA��$��Label��$
��Left=�$��	74,13,0,0q�$	��Top=��� -   $ 
label_Copy��$��Image B��$
��Left=�$��	10,36,0,0q�$	��Top=��� -    ��Name$ 	cboxImage��$
��Left=�$��	74,33,0,0q�$	��Top=�$	��180���� -   $ label2��$
��A = ��$
��Left=�$��	10,68,0,0q�$	��Top=�$��20(�$  Xceed.Wpf.Toolkit.DoubleUpDown  -   $��ratioA��$
��Left=�$��	56,70,0,0q�$	��Top=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�   Minimum$
 -255X�   Maximum$	 255X��� -   $ label2_Copy��$�� * A ��$
��Left=�$��
104,68,0,0q�$	��Top=�$��20(��� -   $ cboxOp��$
��Left=�$��
150,70,0,0q�$	��Top=� �� SelectedIndex$ 0��.@��� $��+���� $��*��  -	   $��ratioB��$
��Left=�$��
193,70,0,0q�$	��Top=�$ 1X�$
 -255X�$	 255X��� -
   $ label2_Copy1��$�� * B ��$
��Left=�$��
241,68,0,0q�$	��Top=�$��20(��� -    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��207,110,0,0q�$	��Top=�$��75���� -   $ btnOK��$��OK��$
��Left=�$��127,110,0,0q�$	��Top=�$��75��